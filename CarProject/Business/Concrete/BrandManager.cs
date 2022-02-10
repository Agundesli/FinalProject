using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager (IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.AddedSuccesful);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.DeletedProduct);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>( _brandDal.GetAll(),Message.AddedSuccesful);
        }

        public IDataResult< List<Brand>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Brand>>( _brandDal.GetAll(p => p.BrandId == id),Message.AddedSuccesful);
        }

        public IResult Update(Brand brand)
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorResult(Message.Maintenancetime);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Message.UpdatedProduct);
        }
    }
}
