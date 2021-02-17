using System;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities;
using Entities.Dtos;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AracEkle();
            //TumarAraclariListele();
            //AracDetayiGetir();
            //AracGetir(3);
            //YeniMusteriEkle();
            //YeniBirKiralamaYap();
            TumKiralamaIslemleriniListele();
            //YeniBirKiralamaYap();
            //KiradanDonusTarihiGuncelle();
            //TumKiralamaIslemleriniListele();


        }
        static void KiradanDonusTarihiGuncelle()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            IResult result = rentalManager.UpdateReturnDate(1, DateTime.Now.Date);

        }
        static void TumKiralamaIslemleriniListele()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentDetailList();
            foreach (var item in result.Data)
            {
                Console.WriteLine("Kira No: {0} \t Kiralama Tarihi: {1} \t Kiradan Dönüş Tarihi: {2} \t Müşteri: {3} \t Araç: {4}", 
                    item.RentId, item.RentDate, item.ReturnDate, item.CustomerName,item.CarDescription);
            }
        }
        static void YeniBirKiralamaYap()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer = customerManager.GetById(1).Data;
            Car car = carManager.GetById(1).Data;

            IResult result= rentalManager.RentACar(car, customer);

            Console.WriteLine(result.Message);
        }
        static void YeniMusteriEkle()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer = new Customer {  UserId=1,CompanyName = "TBT" };
            customerManager.Add(customer);

        }
        static void AracGetir(int carID) {
            CarManager carManager = new CarManager(new EfCarDal());

            var result2 = carManager.GetById(carID);

            Console.WriteLine("id si {0} olan kayıt:{1}", carID,result2.Data.Description);
        }
        static void AracDetayiGetir() {
            CarManager carManager = new CarManager(new EfCarDal());
            var result3 = carManager.GetCarDetails();

            foreach (var item in result3.Data)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }
        }
        static void AracEkle() {

            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car { BrandId = 3, ColorId = 4, DailyPrice = 50, ModelYear = 2006, Description = "Deneme" };
            carManager.Add(car);

            car = new Car { BrandId = 3, ColorId = 2, DailyPrice = 160, ModelYear = 2010, Description = "Test" };
            carManager.Add(car);
        }

        static void TumarAraclariListele() {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", item.Id, item.BrandId, item.ModelYear, item.DailyPrice, item.Description);
            }
        }
    }
}
