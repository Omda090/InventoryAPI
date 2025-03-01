using Dapper;
using InventoryAPI.Interface;
using InventoryAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InventoryAPI.Implementation
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task<int> AddInventoryItem(InventoryItem item)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Name", item.Name);
            parameters.Add("@Description", item.Description);
            parameters.Add("@Price", item.Price);
            parameters.Add("@StockQuantity", item.StockQuantity);
            parameters.Add("@CategoryId", item.CategoryId);
            parameters.Add("@SupplierId", item.SupplierId);
            parameters.Add("@CreatedBy", item.CreatedBy);
            parameters.Add("@CreatedAt", dbType: DbType.DateTime, direction: ParameterDirection.Output);

            var newId = await connection.ExecuteScalarAsync<int>(
                "AdddInventoryItem",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return newId;
        }

        public async Task UpdateInventoryItem(InventoryItem item)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                "UpdateInventoryItemm",
                new
                {
                    item.Id,
                    item.Name,
                    item.Description,
                    item.Price,
                    item.StockQuantity,
                    item.CategoryId,
                    item.SupplierId,
                    item.UpdatedBy
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteInventoryItem(int id, int deletedBy)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                "DeleteInventoryItemm",
                new { Id = id, DeletedBy = deletedBy },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<InventoryItem>> GetInventoryItems(int pageNumber, int pageSize, string sortColumn, string sortOrder)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<InventoryItem>(
                "GetInventoryItemss",
                new { PageNumber = pageNumber, PageSize = pageSize, SortColumn = sortColumn, SortOrder = sortOrder },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
