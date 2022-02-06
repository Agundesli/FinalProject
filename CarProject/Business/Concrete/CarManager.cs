using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByCarId(int id)
        {
            return _carDal.GetAll(p => p.CarId == id);
        }
    }
}
