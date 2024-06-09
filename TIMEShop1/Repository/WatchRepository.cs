using Microsoft.EntityFrameworkCore;
using TIMEShop1.Data;
using TIMEShop1.Interfaces;
using TIMEShop1.Models;

namespace TIMEShop1.Repository
{
    public class WatchRepository : IWatchRepository
    {
        private readonly ApplicationDbContext _context;

        public WatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Watch watch)
        {
            _context.Add(watch);
            return Save();
        }

        public bool Delete(Watch watch)
        {
            _context.Remove(watch);
            return Save();
        }

        public async Task<IEnumerable<Watch>> GetAll()
        {
            return await _context.Watches.ToListAsync();
        }

        public async Task<Watch> GetByIdAsync(int id)
        {
            return await _context.Watches.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Watch> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Watches.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Watch>> GetWatchByBrand(string brand)
        {
            return await _context.Watches.Where(c => c.Brand.Contains(brand)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Watch watch)
        {
            _context.Update(watch);
            return Save();
        }
    }
}
