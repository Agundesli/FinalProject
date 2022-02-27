using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EFCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context= new CarContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.CarId equals c.ColorId
                             join b in context.Brands
                             on p.CarId equals b.BrandId
                             select new CarDetailDto 
                             { 
                                 CarId = p.CarId,
                                 BrandName = b.BrandName, 
                                 ColorName = c.ColorName, 
                                 Description = p.Description
                             };
                return result.ToList();
            }
        }
    }
}
