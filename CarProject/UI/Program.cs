using Business.Concrete;
using Core.Entities.Concrete;
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

            int sayi1 = 5;
            int sayi2 = 10;

            int toplam = sayi1 + sayi2;
            //GetCar();

            //GetBrand();

            //GetBrandKriter();

            //GetColorKriter();

            //MultiJoin();

            //Delete();

            //UpdateColor();

            //BrandUpdate();

            //GetColor();

            //ResultReturn();

            //UserAdded();

            //CustomerAdded();

            //RentalAdded();

            //UserUpdate();

            //Rental();

            //RentalUpdate();

            //CarManager carManager = new CarManager(new EFCarDal());

            //carManager.Add(new Car { BrandId = 2, ColorId = 4, ModelYear = 1996, DailyPrice = 102500, Description = "Classic" });
            //ARABA TABLOSUNA VERİ EKLEDİM

            //carManager.Add((new Car { BrandId = 5, ColorId = 1, ModelYear = 2006, DailyPrice = 55500, Description = "C" }));
            //İŞ KURALI-1 UYULAMDI

            //carManager.Add(new Car { BrandId = 5, ColorId = 1, ModelYear = 2006, DailyPrice = 0, Description = "Cfdfsfsef" });
            //İŞ KURALI-2 UYULMADI
        }

        private static void RentalUpdate()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            rentalManager.Update(new Rental { RentalId = 3028, CarId = 1, CustomerId = 1, ReturnDate = new DateTime(2022, 02, 13) });
            rentalManager.Update(new Rental { RentalId = 4022, CarId = 2, CustomerId = 1, ReturnDate = new DateTime(2022, 02, 14) });
        }

        private static void Rental()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            var r = rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 1,
                RentDate = new DateTime(2022,02,15),
            });
        }

        //private static void UserUpdate()
        //{
        //    UserManager userManager1 = new UserManager(new EFUserDal());
        //    userManager1.Update(new User { UserId = 1,FirstName="Mehmet", LastName="Mehmet", Email= "fbehf@fhefbh", Password = "black" });
        //    userManager1.Update(new User { UserId = 2, FirstName = "Ayşe", LastName = "Ayşe", Email = "fbehf@fhefbh", Password = "White" });
        //    userManager1.Update(new User { UserId = 3, FirstName = "Kamil", LastName = "Kamil", Email = "fbehf@fhefbh", Password = "yellow" });
        //    userManager1.Update(new User { UserId = 4, FirstName = "Yeliz", LastName = "Yeliz", Email = "fbehf@fhefbh", Password = "orange" });
        //    userManager1.Update(new User { UserId = 5, FirstName = "Fırat", LastName = "Fırat", Email = "fbehf@fhefbh", Password = "pink" });
        //}

        private static void RentalAdded()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            rentalManager.Add(new Rental
            {
                CarId = 4,
                CustomerId = 4,
                RentDate = new DateTime(2022, 2, 6),
                ReturnDate = new DateTime(2022, 2, 12)
            });
            rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 3,
                RentDate = new DateTime(2022, 2, 6),
                ReturnDate = new DateTime(2022, 2, 12)
            });
        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Deneme" });
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Test" });
            customerManager.Add(new Customer { UserId = 2, CompanyName = "Yazılım" });
            customerManager.Add(new Customer { UserId = 3, CompanyName = "Bilişim" });
            customerManager.Add(new Customer { UserId = 4, CompanyName = "Grafik" });
            customerManager.Add(new Customer { UserId = 4, CompanyName = "Tasarım" });
        }

        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EFUserDal());
            userManager.Add(new User
            {
                FirstName = "Büşra",
                LastName = "Yılmaz",
                Email = "bsrylmz06@gmail.com",
                //Password = "Gray"
            }
            );
            userManager.Add(new User
            {
                FirstName = "Yusuf",
                LastName = "Gündeşli",
                Email = "yusuf@hotmail.com",
                //Password = 200000
            });

            {

            }
            userManager.Add(new User
            {
                FirstName = "Kürşat",
                LastName = "Gündeşli",
                Email = "kürşat@hotmail.com",
                //Password = 300000
            });
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
            carManager.Delete(new Car { CarId = 2002 });
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
