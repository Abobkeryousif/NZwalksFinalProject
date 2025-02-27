using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Repostries
{
    public interface IImageRepository
    {
        Task<Image>Uplaod(Image image);
    }
}
