using InventoryAPI.Implementation;
using InventoryAPI.Interface;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {


        private readonly IInventoryRepository _inventoryRepo;

        public InventoryController(IInventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] InventoryItem item)
        {
            int newItemId = await _inventoryRepo.AddInventoryItem(item);
            return CreatedAtAction(nameof(GetItems), new { id = newItemId }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] InventoryItem item)
        {
            item.Id = id;
            await _inventoryRepo.UpdateInventoryItem(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id, [FromQuery] int deletedBy)
        {
            await _inventoryRepo.DeleteInventoryItem(id, deletedBy);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetItems(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortColumn = "CreatedAt",
            [FromQuery] string sortOrder = "ASC")
        {
            var items = await _inventoryRepo.GetInventoryItems(pageNumber, pageSize, sortColumn, sortOrder);
            return Ok(items);
        }
    }
}
