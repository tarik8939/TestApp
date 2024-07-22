export interface Category {
  categoryId: number;
  categoryName: string;
  parentCategoryId: number | null;
  parentCategory: Category;
  subCategories: Category[];
}
