using CapstoneServiceBookingAPI.Models;

namespace CapstoneServiceBookingAPI.Services
{
    public interface IAppProductService
    {
        Task<IEnumerable<AppProduct>> GetAllProductsAsync(int id);
        Task<AppProduct> GetProductByIdAsync(int id);
        Task CreateProductAsync(AppProduct product);
        Task UpdateProductAsync(AppProduct product);
        Task DeleteProductAsync(int id);
    }
}
