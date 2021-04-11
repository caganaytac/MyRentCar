using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilePhotosController : ControllerBase
    {
        private readonly IUserProfilePhotoService _userProfilePhotoService;

        public UserProfilePhotosController(IUserProfilePhotoService userProfilePhotoService)
        {
            _userProfilePhotoService = userProfilePhotoService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userProfilePhotoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userProfilePhotoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            var result = _userProfilePhotoService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm(Name = "UserId")] UserProfilePhoto userProfilePhoto)
        {
            var result = _userProfilePhotoService.Add(file, userProfilePhoto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm(Name = "Id")] UserProfilePhoto userProfilePhoto)
        {
            var image = _userProfilePhotoService.GetById(userProfilePhoto.Id).Data;
            var result = _userProfilePhotoService.Update(file, image);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = "Id")] UserProfilePhoto userProfilePhoto)
        {
            var image = _userProfilePhotoService.GetById(userProfilePhoto.Id).Data;
            var result = _userProfilePhotoService.Delete(image);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
