export interface IngredientDto {
  name: string;
  quantity: number;
  unit: string;
}

export interface RecipeDto {
  id: string;
  title: string;
  description: string;
  difficulty: string;
  preparationTime: number;
  cookingTime: number;
  categoryName: string;
  ingredients: IngredientDto[];
}

export interface CreateRecipeDto {
  title: string;
  description: string;
  difficulty: string;
  preparationTimeValue: number;
  preparationTimeUnit: string;
  cookingTimeValue: number;
  cookingTimeUnit: string;
  categoryId: string;
}
