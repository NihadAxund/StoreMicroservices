﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ImageServiceApi.Dtos;
using ImageServiceApi.Helpers;

namespace ImageServiceApi.Services
{
    public class PhotoService : IPhotoService
    {
        private IConfiguration _configuration;
        private CloudinarySettings _cloudinarySettings;
        private Cloudinary _cloudinary;

        public PhotoService(IConfiguration configuration)
        {
            _configuration = configuration;
            _cloudinarySettings = _configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new Account(_cloudinarySettings.CloudName,
                _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret);
            _cloudinary = new Cloudinary(account);


        }

        public string UploadImage(PhotoCreationDto dto)
        {
            var file = dto.File;
            var uploadResult = new ImageUploadResult();
            if (file?.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                    if (uploadResult != null)
                    {
                        return uploadResult.Url.ToString();
                    }
                    return "";
                }
            }
            return "";
        }
    }
}
