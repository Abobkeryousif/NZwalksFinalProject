using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Repostries
{
    public interface IWalkRepository
    {
        Task<Walk>CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? FilterOn = null, string? FilterQuery = null,string? sortBy = null, bool isAscending = true,
            int PageNumber = 1 , int PageSize = 1000);
        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateWalkAsync(Guid ID, Walk walk);

        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
