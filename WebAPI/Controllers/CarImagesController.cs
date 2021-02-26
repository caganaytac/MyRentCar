using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        private IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallbycarid")]
        public IActionResult GetAllByCarId(int id)
        {
            var result = _carImageService.GetAllByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            System.IO.FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var path = Path.GetTempFileName();
            if (file.Length > 0)
                await using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);

            carImage = new CarImage { CarId = carImage.CarId, ImagePath = path, Date = DateTime.Now };

            var result = _carImageService.Add(carImage, fileExtension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add2")]
        public IActionResult Add(CarImage carImage)
        {
            var result = _carImageService.Add(carImage,"");
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        public class FileUpload
        {
            public IFormFile files { get; set; }
            public IFormFile carId { get; set; }
        }

        [HttpPost("add3")]
        public async Task<string> Add3([FromForm] FileUpload file, [FromForm] CarImage carImage)
        {
            System.IO.FileInfo ff = new FileInfo(file.files.FileName);
            string fileExtension = ff.Extension;

            var createdUniqueFileName = Guid.NewGuid().ToString("N")
                                        + "_" + DateTime.Now.Month + "_"
                                        + DateTime.Now.Day + "_"
                                        + DateTime.Now.Year + fileExtension;
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\uploads\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\uploads\\");
            }

            using (FileStream fs = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\uploads\\" + createdUniqueFileName))
            {
                await file.files.CopyToAsync(fs);
                fs.Flush();
            }

            await AddAsync(file.files, carImage);
            return "\\uploads\\" + createdUniqueFileName;
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
