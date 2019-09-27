import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Recipe } from 'src/app/model/recipe-management';
import { SaveRecipeResponse } from '../web-seeker/web-seeker.service';

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

  getRecipes(dishId: number): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`${this.baseUrl}api/RecipeManagement/Recipes?DishId=${dishId}`);
  }

  public saveRecipe(recipe: Recipe): Observable<SaveRecipeResponse> {
    return this.http.post<SaveRecipeResponse>(`${this.baseUrl}api/RecipeManagement/SaveRecipe`, recipe);
  }
}

export class Dish {
  id: number;
}
