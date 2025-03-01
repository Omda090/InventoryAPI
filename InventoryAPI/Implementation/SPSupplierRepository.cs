using Dapper;
using InventoryAPI.Interface;
using InventoryAPI.Models;
using System.Data;

namespace InventoryAPI.Implementation
{
    public class SPSupplierRepository : ISupplierRepository
    {
        private readonly string _connectionString;
        private readonly IDbConnection _dbConnection;

        public SPSupplierRepository(IConfiguration configuration, IDbConnection dbConnection)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbConnection = dbConnection;
        }

        public IEnumerable<Supplier> GetSuppliers(int page, int pageSize, string sortColumn, string sortOrder)
        {
            return _dbConnection.Query<Supplier>(
                "GetSuppliers",
                new { Page = page, PageSize = pageSize, SortColumn = sortColumn, SortOrder = sortOrder },
                commandType: CommandType.StoredProcedure
            );
        }


        public Supplier GetSupplierById(int id)
        {
            return _dbConnection.QueryFirstOrDefault<Supplier>(
                "GetSupplierById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }


        public void AddSupplier(Supplier supplier)
        {
            _dbConnection.Execute(
                "AddSupplier",
                new
                {
                    supplier.Name,
                    supplier.ContactPerson,
                    supplier.Phone,
                    supplier.Email,
                    supplier.Address,
                    supplier.CreatedBy
                },
                commandType: CommandType.StoredProcedure
            );
        }


        public void UpdateSupplier(Supplier supplier)
        {
            _dbConnection.Execute(
                "UpdateSupplier",
                new
                {
                    supplier.Id,
                    supplier.Name,
                    supplier.ContactPerson,
                    supplier.Phone,
                    supplier.Email,
                    supplier.Address,
                    supplier.UpdatedBy
                },
                commandType: CommandType.StoredProcedure
            );
        }


        public void DeleteSupplier(int id)
        {
            _dbConnection.Execute(
                "DeleteSupplier",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }


    }
}
