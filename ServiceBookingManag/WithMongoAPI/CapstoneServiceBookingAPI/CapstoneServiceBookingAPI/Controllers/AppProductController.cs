using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneServiceBookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using CapstoneServiceBookingAPI.Models;

namespace CapstoneServiceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class AppProductController : ControllerBase
    {
        private readonly IAppProductService _productService;

        public AppProductController(IAppProductService productService)
        {
            _productService = productService;
        }

        // Get all products (accessible by all users)
        [HttpGet("GetAllProducts/{id}")]
        public async Task<IActionResult> GetAllProducts(string id)
        {
            var products = await _productService.GetAllProductsAsync(id);
            return Ok(new { status = "success", msg = "Products retrieved", products });
        }

        // Get product by ID (accessible by all users)
        [HttpGet("getProduct/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(new { status = "error", msg = "Product not found" });

            return Ok(new { status = "success", msg = "Product retrieved", product });
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] AppProduct product)
        {
            await _productService.CreateProductAsync(product);
            return Ok(new { status = "success", msg = "Product created", payload = product });
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] AppProduct product)
        {
            await _productService.UpdateProductAsync(product);
            return Ok(new { status = "success", msg = "Product updated", payload = product });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok(new { status = "success", msg = "Product deleted" });
        }
    }
}
