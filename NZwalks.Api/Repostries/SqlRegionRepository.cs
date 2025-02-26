using Microsoft.EntityFrameworkCore;
using NZwalks.Api.Data;
using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Repostries
{
    public class SqlRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SqlRegionRepository(NZWalksDbContext dbContext)
        {
         _dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _dbContext.AddAsync(region);
            _dbContext.SaveChanges();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid ID)
        {
            var result = await _dbContext.Regions.FirstOrDefaultAsync(x=> x.Id == ID);
            if (result is null)
            {
            return null;
            }

             _dbContext.Regions.Remove(result);
            await _dbContext.SaveChangesAsync();   
            return result;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
            
        }

        public async Task<Region?> GetByIdAsync(Guid ID)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x=> x.Id == ID);
        }

       

        public async Task<Region?> UpdateAsync(Guid ID, Region region)
        {
            var ExistingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x=> x.Id == ID);
            if (ExistingRegion == null) 
            {
                return null;
            }

            ExistingRegion.Name = region.Name;
            ExistingRegion.Code = region.Code;
            ExistingRegion.RegionImageUrl = region.RegionImageUrl;
            await _dbContext.SaveChangesAsync();
            return ExistingRegion;  
        }
    }
}








