import * as RecipeManagementAction from './recipe-management.actions';
import { createReducer, on, Action } from '@ngrx/store';

export interface RecipeManagementState {
  dishes: {},
  recipe: {},
}

export const initialState = {
  dishes: {},
  recipe: {},
};

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
  }))
);

export function reducer(state: RecipeManagementState, action: Action) {
  return RecipeManagementReducer(state, action);
}
