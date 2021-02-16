using System;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarAdd();
            //CarGet();
            //CarDetailsGet();
            //CarGetByID(3);
            //AddNewCustomer();
            AddNewRent();
        }
        static void AddNewRent()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer = customerManager.GetById(1).Data;
            Car car = carManager.GetById(1).Data;

            IResult result= rentalManager.RentACar(car, customer);

            Console.WriteLine(result.Message);
        }
        static void AddNewCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer = new Customer {  UserId=1,CompanyName = "TBT" };
            customerManager.Add(customer);

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

            Car car = new Car { BrandId = 3, ColorId = 4, DailyPrice = 50, ModelYear = 2006, Description = "Deneme" };
            carManager.Add(car);

            car = new Car { BrandId = 3, ColorId = 2, DailyPrice = 160, ModelYear = 2010, Description = "Test" };
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
