using CapstoneServiceBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Repositories
{
    public interface IAppProductRepo
    {
        Task<IEnumerable<AppProduct>> GetAllProductsAsync(string userId); // Change int to string for MongoDB ObjectId
        Task<AppProduct> GetProductByIdAsync(string id); // Change int to string for MongoDB ObjectId
        Task CreateProductAsync(AppProduct product);
        Task UpdateProductAsync(AppProduct product);
        Task DeleteProductAsync(string id); // Change int to string for MongoDB ObjectId
    }
}
