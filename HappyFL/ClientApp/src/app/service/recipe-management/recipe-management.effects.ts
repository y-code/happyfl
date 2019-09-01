import { Injectable } from '@angular/core';
import { createEffect, Actions, ofType } from '@ngrx/effects';
import { RecipeManagementService } from './recipe-management.service';
import { requestDishes, receiveDishes, requestRecipes, receiveRecipes, requestRecipeSeek, receiveRecipeSeekResult } from './recipe-management.actions';
import { mergeMap, exhaustMap, map, catchError } from 'rxjs/operators';
import { EMPTY, Observable } from 'rxjs';
import { Action } from '@ngrx/store';
import { WebSeekerService } from '../web-seeker.service';

@Injectable()
export class RecipeManagementEffects {

  loadDishes$ = createEffect(() => this.actions$.pipe(
    ofType(requestDishes.type),
    mergeMap(() =>
      this.recipeManagementService.getDishes().pipe(
        map(dishes => ({ type: receiveDishes.type, dishes })),
        catchError(() => EMPTY)
      )
    )
  ));

  loadRecipes$ = createEffect(() => this.actions$.pipe(
    ofType(requestRecipes),
    exhaustMap(action =>
      this.recipeManagementService.getRecipes(action.dishId).pipe(
        map(recipes => receiveRecipes({ dishId: action.dishId, recipes })),
        catchError(() => EMPTY)
      )
    )
  ));

  requestRecipeSeek$ = createEffect(() => this.actions$.pipe(
    ofType(requestRecipeSeek),
    exhaustMap(action =>
      this.webSeekerService.findRecipes(action.url).pipe(
        map(result => receiveRecipeSeekResult({ url: action.url, result })),
        catchError(() => EMPTY)
      )
    )
  ));

  constructor(
    private actions$: Actions,
    private recipeManagementService: RecipeManagementService,
    private webSeekerService: WebSeekerService
  ) {}
}
