import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Recipe, Dish, IngredientSection } from 'src/app/model/recipe-management';
import { SaveRecipeResponse } from '../web-seeker/web-seeker.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RecipeManagementService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  getDishes(): Observable<Dish[]> {
    return this.http.get<Dish[]>(`${this.baseUrl}api/RecipeManagement/Dishes`);
  }

  getRecipesByDish(dishId: number): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`${this.baseUrl}api/RecipeManagement/Recipes?DishId=${dishId}`)
      .pipe(
        map(value => this.postProcessRecipes(value))
      );
  }

  getRecipe(recipeId: number): Observable<Recipe> {
    return this.http.get<Recipe[]>(`${this.baseUrl}api/RecipeManagement/Recipes?RecipeId=${recipeId}`)
      .pipe(
        map(value => {
          var recipes = this.postProcessRecipes(value);
          if (recipes && recipes[0])
            return recipes[0];
          return undefined;
        })
      );
  }

  private postProcessRecipes(recipes: Recipe[]): Recipe[] {
    for (let recipe of recipes) {
      let section: IngredientSection;
      for (let ingredient of recipe.ingredients) {
        if (section && section.id === ingredient.section.id)
          ingredient.section = section;
        else
          section = ingredient.section;
      }
    }
    return recipes;
  }

  public saveRecipe(recipe: Recipe): Observable<SaveRecipeResponse> {
    return this.http.post<SaveRecipeResponse>(`${this.baseUrl}api/RecipeManagement/Recipes`, recipe);
  }
}
