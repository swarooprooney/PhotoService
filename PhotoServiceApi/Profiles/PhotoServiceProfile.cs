using AutoMapper;
using CloudinaryDotNet.Actions;
using PhotoServiceApi.Models;

namespace PhotoServiceApi.Profiles
{
    public class PhotoServiceProfile : Profile
    {
        public PhotoServiceProfile()
        {
            CreateMap<ImageUploadResult, PhotoStoreDto>();
            CreateMap<PhotoStoreDto, PhotoReturnDto>();
        }
    }
}