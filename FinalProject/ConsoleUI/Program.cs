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
            //ProductTest1();
            //CategoryTest();
            ProductTest2();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EntityFrameworkCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest1()
        {
            ProductManager productManager = new ProductManager(new EntityFrameworkProductDal());
            foreach (var item in productManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(item.ProductName);
            }
        }
        private static void ProductTest2()
        {
            ProductManager productManager1 = new ProductManager(new EntityFrameworkProductDal());
            foreach (var item in productManager1.GetProductDetails())
            {
                Console.WriteLine(item.ProductName+"-"+item.CategoryName);
            }
        }
    }
}
