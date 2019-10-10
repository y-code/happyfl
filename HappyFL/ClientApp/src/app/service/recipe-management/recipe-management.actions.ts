import { createAction, props } from '@ngrx/store'
import { ScannedRecipe } from '../web-seeker/web-seeker.service';
import { Recipe, Dish } from 'src/app/model/recipe-management';

export const requestDishes = createAction('[Recipe Management] Request Dishes');
export const receiveDishes = createAction('[Recipe Management] Receive Dishes', props<{
  dishes: Dish[],
}>());
export const requestRecipe = createAction('[Recipe Management] Request Recipe by ID', props<{
  recipeId: number
}>());
export const receiveRecipe = createAction('[Recipe Management] Receive Recipe by ID', props<{
  recipeId: number,
  recipe: Recipe
}>());
export const requestRecipesByDish = createAction('[Recipe Management] Request Recipes by Dish', props<{
  dishId: number
}>());
export const receiveRecipesByDish = createAction('[Recipe Management] Receive Recipe by Dish', props<{
  dishId: number,
  recipes: Recipe[]
}>());
export const requestSaveRecipe = createAction('[Recipe Management] Request Save Recipe', props<{
  recipe: Recipe
}>());
export const receiveResponseForSaveRecipe = createAction('[Recipe Management] Receive Response for Save Recipe', props<{
  isSuccess: boolean,
  message: string,
  recipeId: number,
  dishId: number,
}>());
export const completeSaveRecipe = createAction('[Recipe Management] Complete Save Recipe');
export const closeSaveRecipeMessage = createAction('[Recipe Management] Close Save Recipe Message');
export const requestRecipeSeek = createAction('[Recipe Management] Request Recipe Seek', props<{
  url: string
}>());
export const cancelRecipeSeek = createAction('[Recipe Management] Cancel Recipe Seek', props<{
  url: string
}>());
export const receiveRecipeSeekResult = createAction('[Recipe Management] Receive Recipe Seek Result', props<{
  url: string,
  result: ScannedRecipe
}>());
