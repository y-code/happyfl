import { Component, OnInit, Input, Output, Inject, ViewChild, ElementRef, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebSeekerService, LinkInfo, RecipeSeekResult, ScannedIngredient, ScannedIngredientSection,  } from '../service/web-seeker/web-seeker.service';
import { Store } from '@ngrx/store';
import { requestRecipeSeek, cancelRecipeSeek, requestSaveRecipe } from '../service/recipe-management/recipe-management.actions';
import { Recipe, Ingredient, IngredientSection } from '../model/recipe-management';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'

@Component({
  selector: 'app-recipe-seeker',
  templateUrl: './recipe-seeker.component.html',
  styleUrls: ['./recipe-seeker.component.css'],
})
export class RecipeSeekerComponent implements OnInit {

  @Input()
  @Output()
  public url: string;

  public links: LinkInfo[];
  public imageLinks: LinkInfoPlus[];

  @Input()
  public recipeSeekResult$: Observable<{
    isLoading: boolean,
    url: string,
    data: RecipeSeekResult
  }>;
  public ingredientCandidatesBySection$: Observable<{
    section: ScannedIngredientSection,
    ingredients: ScannedIngredient[]
  }[]>;

  public recipe: Recipe = new Recipe();

  public sections: IngredientSection[] = [];
  public ingredientsBySection: {
    section: IngredientSection,
    ingredients: Ingredient[]
  }[] = [];

  constructor(
    private webSeekerService: WebSeekerService,
    @Inject("BASE_URL") public baseUrl: string,
    private store: Store<{
      recipeManagement: {
        recipeSeekResult: {
          isLoading: boolean,
          url: string,
          data: RecipeSeekResult
        }
      }
    }>,
    private route: ActivatedRoute,
  ) {
    this.recipe = new Recipe();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.url = params.url;

      this.findRecipe(this.url);
    });

    this.recipeSeekResult$ = this.store.select(state => state.recipeManagement.recipeSeekResult).pipe(
      map(r => {

        /* re-initialize this.recipe */
        if (r.data) {
          let recipe = new Recipe();
          let sections: IngredientSection[] = [];
          let ingredientsBySection: {
            section: IngredientSection,
            ingredients: Ingredient[]
          }[] = [];
  
          recipe.name = r.data.names.length ? r.data.names[0] : undefined;
  
          let groups = this.groupBySection(r.data.ingredients);
          for (let group of groups) {
            let section = new IngredientSection();
            let ingredients: {
              section: IngredientSection,
              ingredients: Ingredient[]
            } = { section, ingredients: [] };

            section.id = group.section.id;
            if (group.section.candidates.length)
              section.name = group.section.candidates[0].name;
  
            for (let i in group.ingredients) {
              let scannedIngredient = group.ingredients[i];
              let ingredient: Ingredient;
              if (scannedIngredient.candidates.length)
                ingredient = {
                  ...scannedIngredient.candidates[0],
                  section,
                };
              else {
                ingredient = new Ingredient();
                ingredient.section = section;
              }
              ingredient.id = scannedIngredient.id;
              recipe.ingredients.push(ingredient);
              ingredients.ingredients.push(ingredient);
            }

            sections.push(section);
            ingredientsBySection.push(ingredients);
          }
  
          this.sections = sections;
          this.ingredientsBySection = ingredientsBySection;
          this.recipe = recipe;
        }

        return r;
      })
    );

    this.ingredientCandidatesBySection$ = this.recipeSeekResult$.pipe(
      map(r => this.groupBySection(r.data.ingredients))
    );
  }

  getSiteDomain(): string {
    var parts = this.url.split('/');
    if (parts.length < 3)
      return "";
    else
      return parts[2];
  }

  save() {
    this.store.dispatch(requestSaveRecipe({ recipe: this.recipe }));
  }

  findRecipe(url: string) {
    this.links = undefined;
    this.imageLinks = undefined;

    this.store.dispatch(requestRecipeSeek({url}));
  }

  onCancel() {
    this.store.dispatch(cancelRecipeSeek({ url: this.url }));
  }

  groupBySection(ingredients: Array<ScannedIngredient>): { section: ScannedIngredientSection, ingredients: ScannedIngredient[] }[] {
    let groups = ingredients.reduce(function (gs, x) {
      let s = x.section;
      let g = gs.find((g) => g && g.section === s);
      if (g) {
        g.ingredients.push(x);
      } else {
        gs.push({ section: s, ingredients: [x] });
      }
      return gs;
    }, []);
    return groups;
  }

  extractSectionNameCandidatesFrom(scanned: ScannedIngredientSection): string[] {
    return scanned.candidates.map(c => c.name);
  }
}

class LinkInfoPlus extends LinkInfo {
  public encodedUrl: string;
}
