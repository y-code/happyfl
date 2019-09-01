import { requestDishes, receiveDishes, requestRecipes, receiveRecipes, requestRecipeSeek, receiveRecipeSeekResult } from './recipe-management.actions';
import { createReducer, on } from '@ngrx/store';

export const initialState = {
  dishes: {},
  recipe: {},
};

export const recipeManagementReducer = createReducer(initialState,
  on(requestDishes, state => ({
    ...state,
    dishes: {
      isLoading: true,
    },
  })),
  on(receiveDishes, (state, action) => ({
    ...state,
    dishes: {
      isLoading: false,
      data: action.dishes,
    },
  })),
  on(requestRecipes, (state, action) => ({
    ...state,
    recipes: {
      isLoading: true,
      dishId: action.dishId,
    },
  })),
  on(receiveRecipes, (state, action) => ({
    ...state,
    recipes: {
      isLoading: false,
      dishId: action.dishId,
      data: action.recipes,
    },
  })),
  on(requestRecipeSeek, (state, action) => ({
    ...state,
    recipeSeekResult: {
      isLoading: true,
      url: action.url,
    },
  })),
  on(receiveRecipeSeekResult, (state, action) => ({
    ...state,
    recipeSeekResult: {
      isLoading: false,
      url: action.url,
      data: action.result,
    },
  }))
);
