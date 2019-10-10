import { Injectable } from '@angular/core';
import { createEffect, Actions, ofType } from '@ngrx/effects';
import { RecipeManagementService } from './recipe-management.service';
import * as RecipeManagementAction from './recipe-management.actions';
import { mergeMap, exhaustMap, map, catchError, takeUntil } from 'rxjs/operators';
import { EMPTY } from 'rxjs';
import { Action } from '@ngrx/store';
import { WebSeekerService } from '../web-seeker/web-seeker.service';

@Injectable()
export class RecipeManagementEffects {

  loadDishes$ = createEffect(() => this.actions$.pipe(
    ofType(RecipeManagementAction.requestDishes),
    mergeMap(() =>
      this.recipeManagementService.getDishes().pipe(
        map(dishes => (RecipeManagementAction.receiveDishes({
          dishes
        }))),
        catchError(() => EMPTY)
      )
    )
  ));

  loadRecipe$ = createEffect(() => this.actions$.pipe(
    ofType(RecipeManagementAction.requestRecipe),
    exhaustMap(action =>
      this.recipeManagementService.getRecipe(action.recipeId).pipe(
        map(recipe => RecipeManagementAction.receiveRecipe({
          recipeId: action.recipeId,
          recipe
        })),
        catchError(() => EMPTY)
      )
    )
  ));

  loadRecipesByDish$ = createEffect(() => this.actions$.pipe(
    ofType(RecipeManagementAction.requestRecipesByDish),
    exhaustMap(action =>
      this.recipeManagementService.getRecipesByDish(action.dishId).pipe(
        map(recipes => RecipeManagementAction.receiveRecipesByDish({
          dishId: action.dishId,
          recipes
        })),
        catchError(() => EMPTY)
      )
    )
  ));

  requestRecipeSeek$ = createEffect(() => this.actions$.pipe(
    ofType(RecipeManagementAction.requestRecipeSeek),
    exhaustMap(action =>
      this.webSeekerService.findRecipes(action.url).pipe(
        map(result => RecipeManagementAction.receiveRecipeSeekResult({
          url: action.url,
          result: (result && result.length > 0 ? result[0] : null)
        })),
        catchError(() => EMPTY),
        takeUntil(
          this.actions$.pipe(
            ofType<Action>(RecipeManagementAction.cancelRecipeSeek)
          )
        )
      )
    )
  ));

  requestSaveRecipe$ = createEffect(() => this.actions$.pipe(
    ofType(RecipeManagementAction.requestSaveRecipe),
    exhaustMap(action =>
      this.recipeManagementService.saveRecipe(action.recipe).pipe(
        map(r => RecipeManagementAction.receiveResponseForSaveRecipe({
          isSuccess: r.isSuccess,
          message: r.message,
          recipeId: r.recipeId,
          dishId: r.dishId
        })),
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
