using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCreditScoresController : ControllerBase
    {
        private readonly IUserCreditScoreService _userCreditScoreService;

        public UserCreditScoresController(IUserCreditScoreService userCreditScoreService)
        {
            _userCreditScoreService = userCreditScoreService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userCreditScoreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userCreditScoreService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            var result = _userCreditScoreService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(UserCreditScore userCreditScore)
        {
            var result = _userCreditScoreService.Add(userCreditScore);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(UserCreditScore userCreditScore)
        {
            var result = _userCreditScoreService.Update(userCreditScore);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserCreditScore userCreditScore)
        {
            var result = _userCreditScoreService.Delete(userCreditScore);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
