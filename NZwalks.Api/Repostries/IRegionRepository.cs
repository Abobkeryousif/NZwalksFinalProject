using NZwalks.Api.Models.Domain;
using System.Runtime.InteropServices;

namespace NZwalks.Api.Repostries
{
    public interface IRegionRepository
    {
       Task <List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid ID);

        Task<Region>CreateAsync(Region region);

         Task<Region?>UpdateAsync(Guid ID,Region region);

        Task<Region?> DeleteAsync(Guid ID);
    }
}
