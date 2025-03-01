using InventoryAPI.Models;

namespace InventoryAPI.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(int page, int pageSize, string sortColumn, string sortOrder);
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
