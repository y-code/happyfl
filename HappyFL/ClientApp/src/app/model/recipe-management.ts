export class Recipe {
  id: number;
  name: string;
  servings: number;
  urlOfBase: string;
  dish: Dish;
  ingredients: Ingredient[] = [];
}

export class Dish {
  id: number;
  name: string;
}

export class IngredientSection {
  id: number;
  name: string;
}

export class Ingredient {
  id: number;
  name: string;
  amount: number;
  unit: string;
  note: string;
  section: IngredientSection = new IngredientSection();
}
