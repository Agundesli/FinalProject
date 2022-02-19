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
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("add")]
        public IActionResult Add(Customer  customer)
        {
            var r = _customerService.Add(customer);
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
        public IActionResult Delete(Customer customer)
        {
            var r = _customerService.Delete(customer);
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
        public IActionResult Update(Customer customer)
        {
            var r = _customerService.Update(customer);
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
            var r = _customerService.GetAll();
            if (r.Success)
            {
                return Ok(r);
            }
            else
            {
                return BadRequest(r);
            }
        }
        [HttpGet("getbycustomerid")]
        public IActionResult getbycustomerid(int id)
        {
            var r = _customerService.GetCustomersByCustomerId(id);
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
