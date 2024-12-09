using CapstoneServiceBookingAPI.Data;
using CapstoneServiceBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneServiceBookingAPI.Repositories
{
    public class AppProductRepo : IAppProductRepo
    {
        private readonly ServiceBookingManagementDbContext _context;

        public AppProductRepo(ServiceBookingManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppProduct>> GetAllProductsAsync(int id)
        {
            return await _context.AppProducts.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<AppProduct> GetProductByIdAsync(int id)
        {
            return await _context.AppProducts.FindAsync(id);
        }

        public async Task CreateProductAsync(AppProduct product)
        {
            await _context.AppProducts.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(AppProduct product)
        {
            _context.AppProducts.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.AppProducts.FindAsync(id);
            if (product != null)
            {
                _context.AppProducts.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
