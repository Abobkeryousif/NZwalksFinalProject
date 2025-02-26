using Microsoft.EntityFrameworkCore;
using NZwalks.Api.Data;
using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Repostries
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _nZWalksDbContext;

        public SqlWalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            _nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _nZWalksDbContext.Walks.AddAsync(walk);
            await _nZWalksDbContext.SaveChangesAsync();
            return walk;

        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var existingwalk = await _nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingwalk is null)
            {
                return null;
            }
            _nZWalksDbContext.Walks.Remove(existingwalk);
            await _nZWalksDbContext.SaveChangesAsync();
            return existingwalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? FilterOn = null, string? FilterQuery = null, string? sortBy = null,
        bool isAscending = true, int PageNumber = 1, int PageSize = 1000)
        {
            var Walk = _nZWalksDbContext.Walks.Include("Region").Include("Difficulty").AsQueryable();

            //filtering
            if (string.IsNullOrWhiteSpace(FilterOn) == false && string.IsNullOrWhiteSpace(FilterQuery) == false)
            {
                if (FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    Walk = Walk.Where(x => x.Name.Contains(FilterQuery));
                }

            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    Walk = isAscending ? Walk.OrderBy(x => x.Name) : Walk.OrderByDescending(x => x.Name);

                }
            else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                    {
                        Walk = isAscending ? Walk.OrderBy(x => x.LengthInKm) : Walk.OrderByDescending(x => x.LengthInKm);
                    }

            }
            //pagnation
            var ResultSkip = (PageNumber - 1) * PageSize;


            return await Walk.Skip(ResultSkip).Take(PageSize).ToListAsync();

        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _nZWalksDbContext.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateWalkAsync(Guid ID, Walk walk)
        {
            var ExistingWalk = await _nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == ID);
            if (ExistingWalk is null)
            {
                return null;
            }

            ExistingWalk.Name = walk.Name;
            ExistingWalk.Description = walk.Description;
            ExistingWalk.LengthInKm = walk.LengthInKm;
            ExistingWalk.WalkIamgeUrl = walk.WalkIamgeUrl;
            ExistingWalk.Region = walk.Region;
            ExistingWalk.Difficulty = walk.Difficulty;

            await _nZWalksDbContext.SaveChangesAsync();
            return ExistingWalk;
        }
    }
}
