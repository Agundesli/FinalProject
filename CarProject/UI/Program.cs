using Business.Concrete;
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
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            //ARABA TABLOSUNDAKİ ÜRÜNLERİ GETİRDİM

            BrandManager brandManager = new BrandManager(new EFBrandDal());
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandName);
            }
            //MARKA TABLOSUNDAKİ ÜRÜNLERİ GETİRDİM

            foreach (var item in brandManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(item.BrandName);
            }
            //MARKA TABOLUSNDAN KRİTER İLE VERİ ALDIM

            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var item in colorManager.GetCarsByColorId(3))
            {
                Console.WriteLine(item.ColorName);
            }
            //RENK TABOLUSNDAN KRİTER İLE VERİ ALDIM

            carManager.Add(new Car { BrandId = 2, ColorId = 4, ModelYear = 1996, DailyPrice = 102500, Description = "Classic" });
            //ARABA TABLOSUNA VERİ EKLEDİM
            carManager.Add(new Car { BrandId = 5, ColorId = 1, ModelYear = 2006, DailyPrice = 55500, Description = "C" });
            //İŞ KURALI-1 UYULAMDI
            carManager.Add(new Car { BrandId = 5, ColorId = 1, ModelYear = 2006, DailyPrice = 0, Description = "C" });
            //İŞ KURALI-2 UYULMADI
        }
    }
}
