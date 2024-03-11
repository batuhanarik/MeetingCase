using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileImagesController : ControllerBase
    {
        //IoC --> Inversion of Control
        private IProfileImageService _profileImageService;

        public ProfileImagesController(IProfileImageService weddingPlaceImageService)
        {
            _profileImageService = weddingPlaceImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _profileImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _profileImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getimagebyuserid")]
        public IActionResult GetImageByUserId(int id)
        {
            var result = _profileImageService.GetImageByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] int userId)
        {
            var result = _profileImageService.Add(file,new ProfileImage { UserId=userId});
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("ProfileImage"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
        {
            var profileImage = _profileImageService.GetById(id).Data;
            var result = _profileImageService.Update(profileImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ProfileImage profileImage)
        {
            var result = _profileImageService.Delete(profileImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
