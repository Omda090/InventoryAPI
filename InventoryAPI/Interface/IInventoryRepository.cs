using InventoryAPI.Models;

namespace InventoryAPI.Interface
{
    public interface IInventoryRepository
    {

  
        //IEnumerable<Item> GetItems();

        Task<int> AddInventoryItem(InventoryItem item);
        Task UpdateInventoryItem(InventoryItem item);
        Task DeleteInventoryItem(int id, int deletedBy);
        Task<IEnumerable<InventoryItem>> GetInventoryItems(int pageNumber, int pageSize, string sortColumn, string sortOrder);
    }
}
