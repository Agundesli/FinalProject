using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length<5)
            {
                return new ErrorResult(Message.InvalidProductName);
            }
            else if (car.DailyPrice==0)
            {
                return new ErrorResult(Message.NoPriceEntried);
            }
               _carDal.Add(car);
            return new SuccessResult(Message.AddedSuccesful);
            
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

        public IDataResult<List<Car>> GetCarsByCarId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarId == id));
        }

        public IDataResult<List<Car>> GetCarsBycolorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == id));
        }

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
