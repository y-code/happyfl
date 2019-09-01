import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Recipe } from '../service/recipe-management/recipe-management.service';
import { requestRecipes } from '../service/recipe-management/recipe-management.actions';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {

  recipes$ = this.store.select(state => state.recipeManagement.recipes);

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
    this.store.dispatch(requestRecipes({ dishId: this.route.snapshot.queryParams.dishId }));
  }

}
