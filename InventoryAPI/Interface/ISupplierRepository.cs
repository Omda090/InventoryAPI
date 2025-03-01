using InventoryAPI.Models;

namespace InventoryAPI.Interface
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers(int page, int pageSize, string sortColumn, string sortOrder);
        Supplier GetSupplierById(int id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
    }
}
