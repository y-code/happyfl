import * as RecipeManagementAction from './recipe-management.actions';
import { createReducer, on, Action } from '@ngrx/store';
import { Notification, NotificationType } from 'src/app/model/notification';

export class RecipeManagementState {
  dishes = {};
  recipe = {};
  recipesByDish = {};
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
  on(RecipeManagementAction.requestRecipesByDish, (state, action) => ({
    ...state,
    recipesByDish: {
      isLoading: true,
      dishId: action.dishId,
    },
  })),
  on(RecipeManagementAction.receiveRecipesByDish, (state, action) => ({
    ...state,
    recipesByDish: {
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
      notification: new Notification(action.isSuccess ? NotificationType.success : NotificationType.error, action.message),
      recipeId: action.recipeId,
      dishId: action.dishId,
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
  })),
  on(RecipeManagementAction.requestRecipe, (state, action) => ({
    ...state,
    recipe: {
      isLoading: true,
      recipeId: action.recipeId,
    }
  })),
  on(RecipeManagementAction.receiveRecipe, (state, action) => ({
    ...state,
    recipe: {
      ...state.recipe,
      isLoading: false,
      data: action.recipe,
    }
  }))
);

export function reducer(state: RecipeManagementState, action: Action) {
  return RecipeManagementReducer(state, action);
}
