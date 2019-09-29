import * as RecipeManagementAction from './recipe-management.actions';
import { createReducer, on, Action } from '@ngrx/store';
import { Notification, NotificationType } from 'src/app/model/notification';

export class RecipeManagementState {
  dishes = {};
  recipe = {};
  recipeSeekResult = {};
  saveRecipe = {};
}

export const initialState: RecipeManagementState = new RecipeManagementState();

export const RecipeManagementReducer = createReducer(initialState,
  on(RecipeManagementAction.requestDishes, state => ({
    ...state,
    dishes: {
      isLoading: true,
    },
  })),
  on(RecipeManagementAction.receiveDishes, (state, action) => ({
    ...state,
    dishes: {
      isLoading: false,
      data: action.dishes,
    },
  })),
  on(RecipeManagementAction.requestRecipes, (state, action) => ({
    ...state,
    recipes: {
      isLoading: true,
      dishId: action.dishId,
    },
  })),
  on(RecipeManagementAction.receiveRecipes, (state, action) => ({
    ...state,
    recipes: {
      isLoading: false,
      dishId: action.dishId,
      data: action.recipes,
    },
  })),
  on(RecipeManagementAction.requestRecipeSeek, (state, action) => ({
    ...state,
    recipeSeekResult: {
      isLoading: true,
      isCancelled: false,
      url: action.url,
    },
  })),
  on(RecipeManagementAction.cancelRecipeSeek, (state, action) => ({
    ...state,
    recipeSeekResult: {
      isLoading: false,
      isCancelled: true,
      url: action.url,
    },
  })),
  on(RecipeManagementAction.receiveRecipeSeekResult, (state, action) => ({
    ...state,
    recipeSeekResult: {
      isLoading: false,
      isCancelled: false,
      url: action.url,
      data: action.result,
    },
  })),
  on(RecipeManagementAction.requestSaveRecipe, (state, action) => ({
    ...state,
    saveRecipe: {
      isSaving: true,
    },
  })),
  on(RecipeManagementAction.receiveResponseForSaveRecipe, (state, action) => ({
    ...state,
    saveRecipe: {
      isSaving: false,
      isSuccess: action.isSuccess,
      notification: new Notification(NotificationType.success, action.message),
    }
  })),
  on(RecipeManagementAction.completeSaveRecipe, (state, action) => ({
    ...state,
    saveRecipe: {
      ...state.saveRecipe,
      isSaving: false,
      isSuccess: undefined,
    }
  })),
  on(RecipeManagementAction.closeSaveRecipeMessage, (state, action) => ({
    ...state,
    saveRecipe: {
      ...state.saveRecipe,
      notification: undefined,
    }
  }))
);

export function reducer(state: RecipeManagementState, action: Action) {
  return RecipeManagementReducer(state, action);
}
