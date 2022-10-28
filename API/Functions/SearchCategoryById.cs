using API.Models;

namespace API.Functions
{
    public static class SearchCategoryById
    {
        public static string GetCategory(IEnumerable<CategoryModel> categories, string? id)
        {
            string categoryName = null;
            foreach(CategoryModel category in categories)
            {
                if (id == category.ID.ToString()) categoryName = category.Category;
            }
            return categoryName;
        }
    }
}
