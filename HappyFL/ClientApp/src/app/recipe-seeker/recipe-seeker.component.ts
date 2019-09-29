import { Component, OnInit, Input, Output, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WebSeekerService, LinkInfo, ScannedRecipe, ScannedIngredient, ScannedIngredientSection,  } from 'src/app/service/web-seeker/web-seeker.service';
import { Store } from '@ngrx/store';
import { requestRecipeSeek, cancelRecipeSeek, requestSaveRecipe, completeSaveRecipe } from 'src/app/service/recipe-management/recipe-management.actions';
import { Recipe, Ingredient, IngredientSection, Dish } from 'src/app/model/recipe-management';
import { Notification } from 'src/app/model/notification';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-recipe-seeker',
  templateUrl: './recipe-seeker.component.html',
  styleUrls: ['./recipe-seeker.component.css'],
})
export class RecipeSeekerComponent implements OnInit {

  @Input()
  @Output()
  public url: string;

  @Input()
  public recipeSeekResult$: Observable<{
    isLoading: boolean,
    url: string,
    data: ScannedRecipe,
  }>;

  public ingredientCandidatesBySection$: Observable<{
    section: ScannedIngredientSection,
    ingredients: ScannedIngredient[],
  }[]>;

  public saveRecipe$: Observable<{
    isSaving: boolean,
    isSuccess: boolean,
    message: Notification,
  }>;

  public recipe: Recipe = new Recipe();

  public sections: IngredientSection[] = [];
  public ingredientsBySection: {
    section: IngredientSection,
    ingredients: Ingredient[],
  }[] = [];

  constructor(
    private webSeekerService: WebSeekerService,
    @Inject("BASE_URL") public baseUrl: string,
    private store: Store<{
      recipeManagement: {
        recipeSeekResult: {
          isLoading: boolean,
          url: string,
          data: ScannedRecipe
        },
        saveRecipe: {
          isSaving: boolean,
          isSuccess: boolean,
          message: Notification,
        },
      }
    }>,
    private route: ActivatedRoute,
    private router: Router
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
  
          recipe.name = r.data.dish.candidates.length ? `${r.data.dish.candidates[0].name} from ${this.getRecipeSiteDomain()}` : undefined;
 
          recipe.dish = r.data.dish.candidates.length ? { ...r.data.dish.candidates[0] } : new Dish();
          
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

    this.saveRecipe$ = this.store.select(state => state.recipeManagement.saveRecipe);
    this.saveRecipe$.subscribe(r => {
      if (!r || r.isSaving || typeof(r.isSuccess) !== "boolean")
        return;
      
      if (!r.isSuccess)
        return;

      this.store.dispatch(completeSaveRecipe({}));
      this.router.navigate(["dishes"]);
    });
  }

  getRecipeSiteDomain(): string {
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
}
