using Business.Abstract;
using Core.Entities.Concrete;
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
    public class UsersController : ControllerBase
    {
        //IUserService _userService;

        //public UsersController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        //[HttpPost("add")]
        //public IActionResult Add(User user)
        //{
        //    var r = _userService.Add(user);
        //    if (r.Success)
        //    {
        //        return Ok(r);
        //    }
        //    else
        //    {
        //        return BadRequest(r);
        //    }
        //}

        //[HttpDelete("delete")]
        //public IActionResult Delete(User user)
        //{
        //    var r = _userService.Delete(user);
        //    if (r.Success)
        //    {
        //        return Ok(r);
        //    }
        //    else
        //    {
        //        return BadRequest(r.Message);
        //    }
        //}

        //[HttpPut("update")]
        //public IActionResult Update(User user)
        //{
        //    var r = _userService.Update(user);
        //    if (r.Success)
        //    {
        //        return Ok(r);
        //    }
        //    else
        //    {
        //        return BadRequest(r);
        //    }
        //}

        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var r = _userService.GetAll();
        //    if (r.Success)
        //    {
        //        return Ok(r);
        //    }
        //    else
        //    {
        //        return BadRequest(r);
        //    }
        //}

        //[HttpGet("getbyuserid")]
        //public IActionResult getbyuserid(int id)
        //{
        //    var r = _userService.GetUsersByUserId(id);
        //    if (r.Success)
        //    {
        //        return Ok(r);
        //    }
        //    else
        //    {
        //        return BadRequest(r.Message);
        //    }
        //}
    }
}
