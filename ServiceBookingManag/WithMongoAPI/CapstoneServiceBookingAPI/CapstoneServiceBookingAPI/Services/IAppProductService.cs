using CapstoneServiceBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Services
{
    public interface IAppProductService
    {
        Task<IEnumerable<AppProduct>> GetAllProductsAsync(string userId); // Changed int to string for MongoDB ObjectId
        Task<AppProduct> GetProductByIdAsync(string id); // Changed int to string for MongoDB ObjectId
        Task CreateProductAsync(AppProduct product);
        Task UpdateProductAsync(AppProduct product);
        Task DeleteProductAsync(string id); // Changed int to string for MongoDB ObjectId
    }
}
