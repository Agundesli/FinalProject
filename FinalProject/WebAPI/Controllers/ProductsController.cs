using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //Bir controller'ın controller olabilmesi için onun ControllerBase'den inheritence edilmesi ve ApiController Attribute
    // alması gerek
    [Route("api/[controller]")]
    [ApiController]//Attribute
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        IProductService _productService;
        //ctor ile dependen injection
        public ProductsController(IProductService productService)//controllera sen bir Iproductservis bağımlısısın
        {
            _productService = productService;//=new ProductManager();
        }

        [HttpGet("getall")]
        
        public IActionResult GetAll()
        {
           //Dependency chain --
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
