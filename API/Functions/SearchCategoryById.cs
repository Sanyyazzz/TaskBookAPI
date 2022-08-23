using API.Models;

namespace API.Functions
{
    public static class SearchCategoryById
    {
        public static string GetCategory(List<CategoryModel> categories, int? id)
        {
            string categoryName = null;
            foreach(CategoryModel category in categories)
            {
                if (id == category.ID) categoryName = category.Category;
            }
            return categoryName;
        }
    }
}
