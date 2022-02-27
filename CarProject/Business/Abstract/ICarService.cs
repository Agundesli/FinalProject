using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult <List<Car>> GetAll();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult <List<Car>> GetCarsBycolorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByCarId(int id);

    }
}
