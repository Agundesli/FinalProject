using Business.Abstract;
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

        public void Add(Car car)
        {
            if (car.Description.Length>5 )
            {
                if (car.DailyPrice>0)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Ürün Eklendi");
                }
                else
                {
                    Console.WriteLine("Fiyat Kuralına Uyulmadı");
                }
            }
            else
            {
                Console.WriteLine("İsim Kuralına Uyulmadı");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.CarId+ " Numaralı Ürün Silindi");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByCarId(int id)
        {
            return _carDal.GetAll(p => p.CarId == id);
        }

        public List<Car> GetCarsBycolorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
             _carDal.Update(car);
            Console.WriteLine(car.CarId+" Numaralı Ürün Güncellendi");

        }
    }
}
