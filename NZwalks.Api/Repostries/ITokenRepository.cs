using Microsoft.AspNetCore.Identity;

namespace NZwalks.Api.Repostries
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user , List<string> Roles);
            
    }
}
