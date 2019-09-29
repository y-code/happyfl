import { createAction, props } from '@ngrx/store'
import { ScannedRecipe } from '../web-seeker/web-seeker.service';
import { Recipe, Dish } from 'src/app/model/recipe-management';

export const requestDishes = createAction('[Recipe Management] Request Dishes');
export const receiveDishes = createAction('[Recipe Management] Receive Dishes', props<{ dishes: Dish[] }>());
export const requestRecipes = createAction('[Recipe Management] Request Recipes', props<{ dishId: number }>());
export const receiveRecipes = createAction('[Recipe Management] Receive Recipe', props<{ dishId: number, recipes: Recipe[] }>());
export const requestSaveRecipe = createAction('[Recipe Management] Request Save Recipe', props<{ recipe: Recipe }>());
export const receiveResponseForSaveRecipe = createAction('[Recipe Management] Receive Response for Save Recipe', props<{ isSuccess: boolean, message: string }>());
export const requestRecipeSeek = createAction('[Recipe Management] Request Recipe Seek', props<{ url: string }>());
export const cancelRecipeSeek = createAction('[Recipe Management] Cancel Recipe Seek', props<{ url: string }>());
export const receiveRecipeSeekResult = createAction('[Recipe Management] Receive Recipe Seek Result', props<{ url: string, result: ScannedRecipe }>());
