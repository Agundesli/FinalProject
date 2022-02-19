using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var r = _brandService.GetAll();
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r);
            }
        }
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var r = _brandService.Add(brand);
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r);
            }
        }
        [HttpDelete("delte")]
        public IActionResult Delete(Brand brand)
        {
            var r = _brandService.Delete(brand);
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(Brand brand)
        {
            var r = _brandService.Update(brand);
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r.Message);
            }
        }
        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var r = _brandService.GetCarsByBrandId(id);
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r.Message);
            }
        }
    }
}
