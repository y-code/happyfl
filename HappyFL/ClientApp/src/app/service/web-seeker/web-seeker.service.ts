import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Recipe, Ingredient, IngredientSection, Dish } from '../../model/recipe-management';

@Injectable({
  providedIn: 'root'
})
export class WebSeekerService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  public findRecipes(url: string): Observable<ScannedRecipe[]> {
    return this.http.get<ScannedRecipe[]>(`${this.baseUrl}api/WebSeeker/FindRecipes?url=${encodeURIComponent(url)}`)
      .pipe(
        map((value, index) => {
          for (let result of value) {
            let section = null;
            for (let ingredient of result.ingredients) {
              if (section && section.id === ingredient.section.id) {
                ingredient.section = section;
              } else {
                section = ingredient.section;
              }
            }
          }
          return value;
        })
      );
  }

  public FindLinksWithImage(url: string): Observable<LinkInfo[]> {
    return this.http.get<LinkInfo[]>(`${this.baseUrl}api/WebSeeker/FindLinksWithImage?url=${encodeURIComponent(url)}`);
  }

  public FindImageLinks(url: string): Observable<LinkInfo[]> {
    return this.http.get<LinkInfo[]>(`${this.baseUrl}api/WebSeeker/FindImageLinks?url=${encodeURIComponent(url)}`);
  }
}

export class LinkInfo {
  public type: string;
  public url: string;
  public caption: string;
}

export class ScannedRecipe {
  name: string;
  servings: number;
  dish: ScannedDish;
  ingredients: ScannedIngredient[];
}

export class ScannedDish {
  id: number;
  candidates: Dish[];
}

export class ScannedIngredient {
  id: number;
  input: string;
  candidates: Ingredient[];
  section: ScannedIngredientSection;
}

export class ScannedIngredientSection {
  id: number;
  candidates: IngredientSection[];
}

export class SaveRecipeResponse {
  isSuccess: boolean;
  message: string;
}
