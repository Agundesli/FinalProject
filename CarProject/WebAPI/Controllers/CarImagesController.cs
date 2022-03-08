using Business.Abstract;
using Core.FileUpload;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        } 

        [HttpPost("add")]
        public IActionResult Add([FromForm] FileUpload file, [FromForm] CarImage carImage)
        {
            
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete(CarImage carImage)
            {
            var carimage = _carImageService.GetByCarImageId(carImage.CarImageId).Data;
                var result = _carImageService.Delete(carimage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }

        [HttpPut("update")]
        public IActionResult Update([FromForm]FileUpload file, [FromForm] CarImage id)
            {
                var carımage = _carImageService.GetByCarImageId(id.CarImageId).Data;
                var result = _carImageService.Update(file,id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

        [HttpGet("getbycarimageid")]
        public IActionResult GetById(int id)
            {
                var result = _carImageService.GetCarImagesByCarId(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
    }
}