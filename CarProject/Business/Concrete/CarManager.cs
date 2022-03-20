using Business.Abstract;
using Business.BussinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Cache;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //[CacheAspect]
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Message.AddedSuccesful);
            
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTets(Car car)
        {
            Add(car);
            if (car.DailyPrice<10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        public IResult Delete(Car car)
        {
            if (DateTime.Now.Hour==13)
            {
                return new ErrorResult(Message.Maintenancetime);
            }

            _carDal.Delete(car);
            return new SuccessResult(Message.DeletedProduct);        
        }
        [CacheAspect]//key,value
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 7)
            //{
            //    return new ErrorDataResult<List<Car>>(Message.Maintenancetime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //if (DateTime.Now.Hour == 7)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Message.Maintenancetime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByCarId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarId == id));
        }

        public IDataResult<List<Car>> GetCarsBycolorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == id));
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorResult(Message.Maintenancetime);
            }
            _carDal.Update(car);
            return new SuccessResult(Message.UpdatedProduct);
        }
    }
}
