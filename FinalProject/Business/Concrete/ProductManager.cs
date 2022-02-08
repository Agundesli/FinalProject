using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //Tnımlanan bir metot bir değer döndürür. Mesela bir list tanımladım bu metot bana bir liste döndürür.
    //Peki aynı anda birden fazla değer döndürmek istiyorsak meselaclisteyi dönder ve mesaj ver.
    //Ya da ürün ekle ve mesaj ver şeklinde birden fazla işlem çalışsın.
    //O zaman metot içerisine encapsülation yapma işine gidiyoruz. 
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new Result(true,"Ürün Eklendi");//Bunu yapabilmem için yöntem bir tane Constructor eklemektir, 2 parametre yolladım.
        }

        public List<Product> GetAll()
        {
            //İş kodları yazılıyor
            //Bir iş sınıfı başka sınıfları new edemez
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryID == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductID == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
