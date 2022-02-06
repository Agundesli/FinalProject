using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductManager productManager = new ProductManager(new EntityFrameworkProductDal());
            foreach (var item in productManager.GetByUnitPrice(40,100)) 
            {
                Console.WriteLine(item.ProductName);
            }

        }
    }
}
