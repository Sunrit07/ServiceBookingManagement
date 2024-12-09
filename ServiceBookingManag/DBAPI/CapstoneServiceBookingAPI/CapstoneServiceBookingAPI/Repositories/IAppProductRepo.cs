using CapstoneServiceBookingAPI.Models;

namespace CapstoneServiceBookingAPI.Repositories
{
    public interface IAppProductRepo
    {
        Task<IEnumerable<AppProduct>> GetAllProductsAsync(int id);
        Task<AppProduct> GetProductByIdAsync(int id);
        Task CreateProductAsync(AppProduct product);
        Task UpdateProductAsync(AppProduct product);
        Task DeleteProductAsync(int id);
    }
}
