import { Component, OnInit, Input, Output, Inject } from '@angular/core';
import { ActivatedRoute, Router, NavigationExtras } from '@angular/router';
import { WebSeekerService, LinkInfo, ScannedRecipe, ScannedIngredient, ScannedIngredientSection,  } from 'src/app/service/web-seeker/web-seeker.service';
import { Store } from '@ngrx/store';
import { requestRecipeSeek, cancelRecipeSeek, requestSaveRecipe, completeSaveRecipe, requestRecipe } from 'src/app/service/recipe-management/recipe-management.actions';
import { Recipe, Ingredient, IngredientSection, Dish } from 'src/app/model/recipe-management';
import { Notification } from 'src/app/model/notification';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-recipe-seeker',
  templateUrl: './recipe-seeker.component.html',
  styleUrls: ['./recipe-seeker.component.scss'],
})
export class RecipeSeekerComponent implements OnInit {

  public url: string;

  public recipeSeekResult$: Observable<{
    isLoading: boolean,
    url: string,
    data: ScannedRecipe,
  }>;

  public ingredientCandidatesBySection$: Observable<{
    section: ScannedIngredientSection,
    ingredients: ScannedIngredient[],
  }[]>;

  public loadRecipe$: Observable<{
    isLoading: boolean,
  }>;

  public saveRecipe$: Observable<{
    isSaving: boolean,
    isSuccess: boolean,
    message: Notification,
    dishId: number,
    recipeId: number,
}>;

  public recipe: Recipe;

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
          dishId: number,
          recipeId: number,
        },
        recipe: {
          isLoading: boolean,
          data: Recipe,
        }
      }
    }>,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params.id) {
        this.store.dispatch(requestRecipe({ recipeId: params.id }));
      } else {
        this.url = params.url;
        this.store.dispatch(requestRecipeSeek({ url: this.url }));
      }
    });

    this.loadRecipe$ = this.store.select(state => state.recipeManagement.recipe).pipe(
      map(r => {
        if (r.isLoading || !r.data)
          return r;
        this.recipe = r.data;
        this.ingredientsBySection = this.groupBySection(this.recipe.ingredients);
        this.url = this.recipe.urlOfBase;

        this.store.dispatch(requestRecipeSeek({ url: this.recipe.urlOfBase }));

        return r;
      })
    );

    this.recipeSeekResult$ = this.store.select(state => state.recipeManagement.recipeSeekResult).pipe(
      map(r => {
        if (r.data && !this.recipe) {
          /* initialize this.recipe */
          let recipe = new Recipe();
          let ingredientsBySection: {
            section: IngredientSection,
            ingredients: Ingredient[]
          }[] = [];
  
          recipe.name = r.data.dish.candidates.length ? `${r.data.dish.candidates[0].name} from ${this.getRecipeSiteDomain()}` : undefined;
          recipe.urlOfBase = this.url;
          recipe.servings = r.data.servings ? r.data.servings : 1;
          recipe.dish = r.data.dish.candidates.length ? { ...r.data.dish.candidates[0] } : new Dish();
          
          let groups = this.groupByScannedSection(r.data.ingredients);
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

            ingredientsBySection.push(ingredients);
          }
  
          this.ingredientsBySection = ingredientsBySection;
          this.recipe = recipe;
        }

        return r;
      })
    );

    this.ingredientCandidatesBySection$ = this.recipeSeekResult$.pipe(
      map(r => this.groupByScannedSection(r.data.ingredients))
    );

    this.saveRecipe$ = this.store.select(state => state.recipeManagement.saveRecipe);
    this.saveRecipe$.subscribe(r => {
      if (!r || r.isSaving || typeof(r.isSuccess) !== "boolean")
        return;
      
      if (!r.isSuccess)
        return;

      this.store.dispatch(completeSaveRecipe());
      this.router.navigate([ "recipes" ], { queryParams: { dishId: r.dishId } });
    });
  }

  getRecipeSiteDomain(): string {
    if (!this.url)
      return;

    var parts = this.url.split('/');
    if (parts.length < 3)
      return "";
    else
      return parts[2];
  }

  save() {
    this.store.dispatch(requestSaveRecipe({ recipe: this.recipe }));
  }

  onCancel() {
    this.store.dispatch(cancelRecipeSeek({ url: this.url }));
  }

  private groupByScannedSection(ingredients: Array<ScannedIngredient>): { section: ScannedIngredientSection, ingredients: ScannedIngredient[] }[] {
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

  private groupBySection(ingredients: Array<Ingredient>): { section: IngredientSection, ingredients: Ingredient[] }[] {
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
