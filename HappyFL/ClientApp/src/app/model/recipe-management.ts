export class Recipe {
  public id: number;
  public name: string;
  public ingredients: Ingredient[] = [];
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
