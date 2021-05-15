using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoServiceApi.Datalayer;
using PhotoServiceApi.Models;
using PhotoServiceApi.Service;

namespace PhotoServiceApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IDatabaseWrapper _wrapper;
        public PhotoController(IPhotoService photoService, IMapper mapper, IDatabaseWrapper wrapper)
        {
            _wrapper = wrapper;
            _photoService = photoService;
            _mapper = mapper;
        }

        [HttpPost("add-profile-photo")]
        public async Task<ActionResult<PhotoReturnDto>> AddPhoto(IFormFile file)
        {
            if (file.Length > 0)
            {
                var uploadPhoto = await _photoService.AddPhotoAsync(file);
                //_map

                var photoStoreDto = _mapper.Map<PhotoStoreDto>(uploadPhoto);
                photoStoreDto.Id = new System.Guid();
                //call a service to store the results in database;
                if (await _wrapper.TryInsertNewRecordAsync<PhotoStoreDto>("Photos", photoStoreDto))
                {
                    return Ok(_mapper.Map<PhotoReturnDto>(photoStoreDto));
                }
            }

            return BadRequest("Unable to update photo");
        }
    }
}