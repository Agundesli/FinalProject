using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using DataAccess.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
            //return new Result(true,"Ürün Eklendi");//Bunu yapabilmem için yöntem bir tane Constructor eklemektir, 2 parametre yolladım.
            return new SuccessResult(Messages.ProductAdded);//overload ile iki farklı yapıcı blok oluşturdum.
            //return new SuccessResult();//Mesaj versin ve vermesin şeklinde. Bool (true olayınıda) arka planda farklı bir clas içerisinde tanımladım.
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //İş kodları yazılıyor
            //Bir iş sınıfı başka sınıfları new edemez
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

         public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccesDataResult<Product>( _productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccesDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
