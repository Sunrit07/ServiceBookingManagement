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

        public async Task<IEnumerable<AppProduct>> GetAllProductsAsync(int id)
        {
            return await _productRepository.GetAllProductsAsync(id);
        }

        public async Task<AppProduct> GetProductByIdAsync(int id)
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

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
