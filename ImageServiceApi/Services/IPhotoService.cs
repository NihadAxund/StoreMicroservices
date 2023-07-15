using ImageServiceApi.Dtos;

namespace ImageServiceApi.Services
{
    public interface IPhotoService
    {
        string UploadImage(PhotoCreationDto dto);
    }
}
