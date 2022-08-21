namespace API.Functions
{
    public class SortParameterBuilder
    {
        public static string GetSortByCategory(string? categoryId)
        {
            return categoryId == null ? "" : $"WHERE CategoryID = {categoryId} ";
        }
    }
}
