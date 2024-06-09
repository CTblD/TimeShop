using TIMEShop1.Models;

namespace TIMEShop1.Interfaces
{
    public interface IWatchRepository
    {
        Task<IEnumerable<Watch>> GetAll();
        Task<Watch> GetByIdAsync(int id);
        Task<Watch> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Watch>> GetWatchByBrand(string brand);
        bool Add(Watch watch);
        bool Update(Watch watch);
        bool Delete(Watch watch);
        bool Save();
    }

}
