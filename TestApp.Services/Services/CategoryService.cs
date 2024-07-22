using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.interfaces;
using TestApp.Domain.Models;
using TestApp.Domain.Repositories;

namespace TestApp.Services.Services
{
    public class CategoryService
    {
        private readonly ICategory _category;

        public CategoryService()
        {
            _category = new CategoryRepository();
        }

        public async Task<List<Category>> GetTree()
        {
            var list = await _category.GetAll();
            var tree = BuildCategoryTree(list);
            return tree;
        }

        private List<Category> BuildCategoryTree(List<Category> categories)
        {
            var categoryLookup = categories.ToDictionary(c => c.CategoryId);
            var roots = new List<Category>();

            foreach (var category in categories)
            {
                if (category.ParentCategoryId.HasValue && categoryLookup.TryGetValue(category.ParentCategoryId.Value, out var parentCategory))
                {
                    parentCategory.SubCategories.Add(category);
                }
                else
                {
                    roots.Add(category);
                }
            }

            return roots;
        }
    }
}
