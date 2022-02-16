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
        IProductService productService;

        public ProductsController(IProductService productService)//controllera sen bir Iproductservis bağımlısısın
        {
            this.productService = productService;
        }

        [HttpGet]
        
        public List<Product> Get()
        {
            //return new List<Product>
            //{
            //    new Product{ProductID=1, ProductName="Elma"},
            //    new Product{ProductID=2, ProductName="Armut"},
            //};
            var result = productService.GetAll();
           
            return result.Data;
        }
    }
}
