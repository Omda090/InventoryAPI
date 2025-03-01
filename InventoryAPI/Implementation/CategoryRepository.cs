using Dapper;
using InventoryAPI.Interface;
using InventoryAPI.Models;
using System.Data;

namespace InventoryAPI.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly IDbConnection _dbConnection;

        public CategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }



        public IEnumerable<Category> GetCategories(int page, int pageSize, string sortColumn, string sortOrder)
        {
            return _dbConnection.Query<Category>(
                "GetCategories",
                new { Page = page, PageSize = pageSize, SortColumn = sortColumn, SortOrder = sortOrder },
                commandType: CommandType.StoredProcedure
            );
        }

        public Category GetCategoryById(int id)
        {
            return _dbConnection.QueryFirstOrDefault<Category>(
                "GetCategoryById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public void AddCategory(Category category)
        {
            _dbConnection.Execute(
                "AddCategory",
                new { category.Name, category.CreatedBy },
                commandType: CommandType.StoredProcedure
            );
        }

        public void UpdateCategory(Category category)
        {
            _dbConnection.Execute(
                "UpdateCategory",
                new { category.Id, category.Name, category.UpdatedBy },
                commandType: CommandType.StoredProcedure
            );
        }

        public void DeleteCategory(int id)
        {
            _dbConnection.Execute(
                "DeleteCategory",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

    }
}
