import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
}

export class Dish {
  id: number;
}

export class Recipe {
  id: number;
}
