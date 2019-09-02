import { Injectable } from '@angular/core';
import { createEffect, Actions, ofType } from '@ngrx/effects';
import { RecipeManagementService } from './recipe-management.service';
import * as RecipeManagementAction from './recipe-management.actions';
import { mergeMap, exhaustMap, map, catchError, takeUntil } from 'rxjs/operators';
import { EMPTY, Observable } from 'rxjs';
import { Action } from '@ngrx/store';
import { WebSeekerService } from '../web-seeker.service';

@Injectable()
export class RecipeManagementEffects {

  loadDishes$ = createEffect(() => this.actions$.pipe(
    ofType(RecipeManagementAction.requestDishes.type),
    mergeMap(() =>
      this.recipeManagementService.getDishes().pipe(
        map(dishes => ({ type: RecipeManagementAction.receiveDishes.type, dishes })),
        catchError(() => EMPTY)
      )
    )
  ));

  loadRecipes$ = createEffect(() => this.actions$.pipe(
    ofType(RecipeManagementAction.requestRecipes),
    exhaustMap(action =>
      this.recipeManagementService.getRecipes(action.dishId).pipe(
        map(recipes => RecipeManagementAction.receiveRecipes({ dishId: action.dishId, recipes })),
        catchError(() => EMPTY)
      )
    )
  ));

  requestRecipeSeek$ = createEffect(() => this.actions$.pipe(
    ofType(RecipeManagementAction.requestRecipeSeek),
    exhaustMap(action =>
      this.webSeekerService.findRecipes(action.url).pipe(
        map(result => RecipeManagementAction.receiveRecipeSeekResult({ url: action.url, result })),
        catchError(() => EMPTY),
        takeUntil(
          this.actions$.pipe(
            ofType<Action>(RecipeManagementAction.cancelRecipeSeek)
          )
        )
      )
    )
  ));

  constructor(
    private actions$: Actions,
    private recipeManagementService: RecipeManagementService,
    private webSeekerService: WebSeekerService
  ) {}
}
