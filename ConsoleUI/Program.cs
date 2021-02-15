using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarAdd()
            //CarGet()
            CarDetailsGet();
            CarGetByID(3);
        }
        static void CarGetByID(int carID) {
            CarManager carManager = new CarManager(new EfCarDal());

            var result2 = carManager.GetById(carID);

            Console.WriteLine("id si {0} olan kayıt:{1}", carID,result2.Data.Description);
        }
        static void CarDetailsGet() {
            CarManager carManager = new CarManager(new EfCarDal());
            var result3 = carManager.GetCarDetails();

            foreach (var item in result3.Data)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }
        }
        static void CarAdd() {

            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car { BrandId = 200, ColorId = 123, DailyPrice = 110, ModelYear = 2006, Description = "Cordoba" };
            carManager.Add(car);

            car = new Car { BrandId = 300, ColorId = 200, DailyPrice = 150, ModelYear = 2020, Description = "Focus" };
            carManager.Add(car);
        }

        static void CarGet() {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", item.Id, item.BrandId, item.ModelYear, item.DailyPrice, item.Description);
            }
        }
    }
}
