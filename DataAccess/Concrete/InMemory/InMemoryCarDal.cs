using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using Entities;
using System.Linq;
using System.Linq.Expressions;
using Entities.Dtos;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> Cars;
        public InMemoryCarDal()
        {
            Cars = new List<Car>
            {
                new Car{ Id=1, BrandId=1, ColorId=1, ModelYear=2004, DailyPrice=50000, Description="Corsa"},
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear=2005,DailyPrice=60000,Description="Astra"},
                new Car{Id=3,BrandId=2,ColorId=3,ModelYear=2007,DailyPrice=70000,Description="Vectra"}
            };
        }
        
        public void Add(Car car)
        {
            Cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = Cars.SingleOrDefault(c => c.Id == car.Id);
            Cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return Cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return Cars.SingleOrDefault(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = Cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

           
        }
    }
}
