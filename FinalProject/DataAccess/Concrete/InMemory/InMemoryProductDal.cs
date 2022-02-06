using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //ctor bellekte referans aldığı zaman new edildiği zaman çalışacak olan blok.
            _products = new List<Product> { 
                new Product { ProductID=1, CategoryID=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product { ProductID=2, CategoryID=1, ProductName="Kamera", UnitPrice=5010, UnitsInStock=3},
                new Product { ProductID=3, CategoryID=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product { ProductID=4, CategoryID=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product { ProductID=5, CategoryID=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
            Console.WriteLine("eklendi");
        }

        public void Delete(Product product)
        {
            //Product productToDelete=null ;
            //foreach (var p in _products)
            //{
            //    if (product.ProductID==p.ProductID)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //Yukarıdaki ifadeye eşdeğer daha sade bir Linq sorgusu
            //ID olan sorgularda genelde singleordefault kullanılır
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductID==product.ProductID);

            _products.Remove(productToDelete);
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }
        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
