using Core.Utilities.Results;
using Core.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(FileUpload objfiles, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(FileUpload objfiles, CarImage carImage);
        IDataResult<CarImage> GetByCarImageId(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetCarImagesByCarId(int id);
    }
}

