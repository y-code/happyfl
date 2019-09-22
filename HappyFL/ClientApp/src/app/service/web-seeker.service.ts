import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WebSeekerService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  public findRecipes(url: string): Observable<RecipeSeekResult[]> {
    return this.http.get<RecipeSeekResult[]>(`${this.baseUrl}api/WebSeeker/FindRecipes?url=${encodeURIComponent(url)}`);
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

export class RecipeSeekResult {
  public names: string[];
  public ingredientsSections: {
    names: string[];
    ingredients: {
      input: string;
      candidates: Ingredient[];
    }[];
  }[];
}

export class Recipe {
  public name: string;
  public ingredientsSections: IngredientsSection[] = [];
}

export class IngredientsSection {
  name: string;
  ingredients: Ingredient[] = [];
}

export class Ingredient {
  name: string;
  amount: number;
  unit: string;
  note: string;
}
