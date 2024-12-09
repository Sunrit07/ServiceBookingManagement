using CapstoneServiceBookingAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Repositories
{
    public class AppProductRepo : IAppProductRepo
    {
        private readonly IMongoCollection<AppProduct> _productCollection;

        public AppProductRepo(IMongoDatabase database)
        {
            _productCollection = database.GetCollection<AppProduct>("AppProducts"); // Replace with your MongoDB collection name
        }

        public async Task<IEnumerable<AppProduct>> GetAllProductsAsync(string userId) // Changed int to string for MongoDB ObjectId
        {
            return await _productCollection.Find(x => x.UserId == userId).ToListAsync(); // Use userId as a string
        }

        public async Task<AppProduct> GetProductByIdAsync(string id) // Changed int to string for MongoDB ObjectId
        {
            return await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync(); // Assuming ProductId is a string
        }

        public async Task CreateProductAsync(AppProduct product)
        {
            await _productCollection.InsertOneAsync(product);
        }

        public async Task UpdateProductAsync(AppProduct product)
        {
            await _productCollection.ReplaceOneAsync(x => x.ProductId == product.ProductId, product); // Assuming ProductId is a string
        }

        public async Task DeleteProductAsync(string id) // Changed int to string for MongoDB ObjectId
        {
            var result = await _productCollection.DeleteOneAsync(x => x.ProductId == id); // Assuming ProductId is a string
            if (result.DeletedCount == 0)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
        }
    }
}
