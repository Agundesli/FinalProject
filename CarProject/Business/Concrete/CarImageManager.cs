﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.BusinessRules;
using Core.FileUpload;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        //IFileService _fileService;

        public CarImageManager(ICarImageDal carImageDal)//IFileService fileService)
        {
            _carImageDal = carImageDal;
            //_fileService = fileService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(FileUpload objfiles, CarImage carImage)
        {
            IResult result = CarImagesRules.Run(CarImageCountCheck(carImage.CarId));
            
            if (result!=null)
            {
                return new ErrorResult(result.Message);
            }
            var imageResult = FileManager.Upload(objfiles);
            carImage.ImagePath = imageResult.Data;//message
            carImage.AddDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Message.AddedSuccesful);
        }

        public IResult Delete( CarImage carImage)
        {
            var image = _carImageDal.Get(p => p.CarImageId == carImage.CarImageId);
            if (image==null)
            {
                return new ErrorResult(Message.ImageNotFound);
            }
            FileManager.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Message.DeletedImage);
        }

        public IDataResult<CarImage> GetByCarImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p=>p.CarImageId==id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {

            IResult result = CarImagesRules.Run(CheckCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckCarImageNull(carId).Data);
        }

        public IResult Update(FileUpload objfiles, CarImage carImage)
        {
            var Isimage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (Isimage==null)
            {
                return new ErrorResult(Message.ImageNotFound);
            }
            var updateFile = FileManager.Update(objfiles, Isimage.ImagePath);
            if (!updateFile.Success)
            {
                return new ErrorResult(updateFile.Message);
            }
            carImage.ImagePath = updateFile.Data;//message
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CarImageCountCheck(int carid)
        {
            var CarImage = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (CarImage<5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Message.CarImageLimitPassed);
        }
        private  IDataResult<List<CarImage>> CheckCarImageNull(int carId)
        {
            try
            {
                string path = @"\images\logo.jpeg";
                var result = _carImageDal.GetAll(p => p.CarId == carId && p.ImagePath == null).Count();
                if (result>0)
                {
                    List<CarImage> carImages = new List<CarImage>();
                    carImages.Add(new CarImage { CarId = carId, ImagePath = path, AddDate = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImages, "liste");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CarImage>>(ex.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList(), "liste");
        }
    }
}
