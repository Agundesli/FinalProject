using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace UI
{
   public class Program
    {
        static void Main(string[] args)
        {
            GetCar();

            //GetBrand();

            //GetBrandKriter();

            //GetColorKriter();

            //MultiJoin();

            //Delete();

            //UpdateColor();

            //BrandUpdate();

            //GetColor();

            //ResultReturn();
            Console.WriteLine(DateTime.Now.Hour);

            //CarManager carManager = new CarManager(new EFCarDal());
            
            //carManager.Add(new Car { BrandId = 2, ColorId = 4, ModelYear = 1996, DailyPrice = 102500, Description = "Classic" });
            //ARABA TABLOSUNA VERİ EKLEDİM
           
            //carManager.Add((new Car { BrandId = 5, ColorId = 1, ModelYear = 2006, DailyPrice = 55500, Description = "C" }));
            //İŞ KURALI-1 UYULAMDI
            
            //carManager.Add(new Car { BrandId = 5, ColorId = 1, ModelYear = 2006, DailyPrice = 0, Description = "Cfdfsfsef" });
            //İŞ KURALI-2 UYULMADI


        }

        private static void ResultReturn()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var r = carManager.GetCarDetails();
            if (r.Success == true)
            {
                foreach (var item in r.Data)
                {
                    Console.WriteLine(item.Description + "-" + item.ColorName + "-" + item.BrandName);
                }
            }
            else
            {
                Console.WriteLine(r.Message);
            }
        }

        private static void BrandUpdate()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            brandManager.Update(new Brand { BrandId = 2, BrandName = "Nissan" });
        }

        private static void UpdateColor()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            colorManager.Update(new Color { ColorId = 4, ColorName = "black" });
        }

        private static void GetColor()
        {
            ColorManager colorManager1 = new ColorManager(new EFColorDal());
            foreach (var item in colorManager1.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void Delete()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Delete(new Car { CarId = 1002 });
            //Database üzerinden veri silme
        }

        private static void MultiJoin()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(item.CarId + " - " + item.Description + " - " + item.BrandName + " - " + item.ColorName);
            }
            //Üç tablo ile inner join yapılamsı
        }

        private static void GetColorKriter()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var item in colorManager.GetCarByColorId(3).Data)
            {
                Console.WriteLine(item.ColorName);
            }
            //RENK TABOLUSNDAN KRİTER İLE VERİ ALDIM
        }

        private static void GetBrandKriter()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            foreach (var item in brandManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(item.BrandName);
            }
            //MARKA TABOLUSNDAN KRİTER İLE VERİ ALDIM
        }

        private static void GetBrand()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandName);
            }
            //MARKA TABLOSUNDAKİ ÜRÜNLERİ GETİRDİM
        }

        private static void GetCar()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.CarId + "-" + item.Description);
            }
            //ARABA TABLOSUNDAKİ ÜRÜNLERİ GETİRDİM
        }
    }
}
