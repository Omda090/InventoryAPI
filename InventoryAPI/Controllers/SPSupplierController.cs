using InventoryAPI.Interface;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPSupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;

        public SPSupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [Authorize(Roles = "Admin")]  // Only users with 'Admin' role can access this controller
        [HttpGet]
        public IActionResult GetSuppliers(int page = 1, int pageSize = 10, string sortColumn = "Id", string sortOrder = "ASC")
        {
            var suppliers = _supplierRepository.GetSuppliers(page, pageSize, sortColumn, sortOrder);
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplier(int id)
        {
            var supplier = _supplierRepository.GetSupplierById(id);
            if (supplier == null)
                return NotFound();
            return Ok(supplier);
        }

        [HttpPost]
        public IActionResult CreateSupplier(Supplier supplier)
        {
            _supplierRepository.AddSupplier(supplier);
            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.Id }, supplier);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, Supplier supplier)
        {
            if (id != supplier.Id)
                return BadRequest();

            _supplierRepository.UpdateSupplier(supplier);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]  // Only users with 'Admin' role can access this controller
        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            _supplierRepository.DeleteSupplier(id);
            return NoContent();
        }

    }
}
