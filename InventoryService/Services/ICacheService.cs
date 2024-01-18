using System.Threading.Tasks;

namespace InventoryService.Services
{
    public interface ICacheService
    {
        Task<string> GetCacheValueAsync(string key);
        Task SetCacheValueAsync(string key, string value);

        Task DeleteKeyAsync(string key);
    }
}