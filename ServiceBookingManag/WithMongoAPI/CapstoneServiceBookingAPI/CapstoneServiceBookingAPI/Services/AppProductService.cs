using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Repositories;

namespace CapstoneServiceBookingAPI.Services
{
    public class AppProductService : IAppProductService
    {
        private readonly IAppProductRepo _productRepository;

        public AppProductService(IAppProductRepo productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<AppProduct>> GetAllProductsAsync(string userId) // Changed int to string for MongoDB
        {
            return await _productRepository.GetAllProductsAsync(userId);
        }

        public async Task<AppProduct> GetProductByIdAsync(string id) // Changed int to string for MongoDB
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task CreateProductAsync(AppProduct product)
        {
            await _productRepository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(AppProduct product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(string id) // Changed int to string for MongoDB
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
