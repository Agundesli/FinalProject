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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var r = _rentalService.Add(rental);
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r);
            }
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            var r = _rentalService.Delete(rental);
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(Rental rental)
        {
            var r = _rentalService.Update(rental);
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r);
            }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var r = _rentalService.GetAll();
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r);
            }
        }
        [HttpGet("getbyrentalid")]
        public IActionResult getbyrentalid(int id)
        {
            var r = _rentalService.GetRentalsByRentalId(id);
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
