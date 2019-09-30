import { Component, OnInit, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { requestRecipes } from '../service/recipe-management/recipe-management.actions';
import { ActivatedRoute } from '@angular/router';
import { Recipe, IngredientSection, Ingredient } from '../model/recipe-management';
import { Observable } from 'rxjs';
import { map, groupBy } from 'rxjs/operators';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss']
})
export class RecipesComponent implements OnInit {

  activeRecipeIndex: number = 0;

  recipes$: Observable<{
    isLoading: boolean,
    dishId: number,
    data: {
      recipe: Recipe,
      ingredientsBySection: {
        section: IngredientSection,
        ingredients: Ingredient[],
      }[]
    }[],
  }>;

  constructor(
    private store: Store<{
      recipeManagement: {
        recipes: {
          isLoading: boolean,
          dishId: number,
          data: Recipe[]
        }
      }
    }>,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.recipes$ = this.store.select(state => state.recipeManagement.recipes).pipe(
      map(r => ({
        ...r,
        data: r.data ? r.data.map(recipe => ({
          recipe,
          ingredientsBySection: this.groupBySection(recipe.ingredients),
        })) : null,
      }))
    );

    this.store.dispatch(requestRecipes({ dishId: this.route.snapshot.queryParams.dishId }));
  }

  groupBySection(ingredients: Array<Ingredient>): { section: IngredientSection, ingredients: Ingredient[] }[] {
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

  showRecipe(index: number) {
    this.activeRecipeIndex = index === this.activeRecipeIndex ? undefined : index;
  }

  getRecipeSiteDomain(url: string): string {
    if (!url)
      return;
      
    var parts = url.split('/');
    if (parts.length < 3)
      return "";
    else
      return parts[2];
  }
}
