using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ CarId=1, BrandId=1, ColorId=1, ModelYear=1980, 
                    DailyPrice=100000, Description="Classic"},
                new Car{ CarId=2, BrandId=2, ColorId=3, ModelYear=2020, 
                    DailyPrice=250000, Description="Sport"},
                new Car{ CarId=3, BrandId=2, ColorId=2, ModelYear=2010, 
                    DailyPrice=50000, Description="Family"},
                new Car{ CarId=4, BrandId=1, ColorId=4, ModelYear=2015,
                    DailyPrice=250000, Description="CommerciaL"},
                new Car{ CarId=5, BrandId=3, ColorId=2, ModelYear=1975,
                    DailyPrice=50000, Description="Ghetto"},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car); 
        }

        public void Delete(Car car)
        {
            Car carDelete = _car.SingleOrDefault(p => p.CarId == car.CarId);
            _car.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(p => p.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
        public void Update(Car car)
        {
            Car carUpdate = _car.SingleOrDefault(p => p.CarId == car.CarId);
            carUpdate.CarId = car.CarId;
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.Description = car.Description;
        }
    }
}
