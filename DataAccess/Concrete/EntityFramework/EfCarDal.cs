using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join r in context.Colors on c.ColorId equals r.Id
                             select new CarDetailDto { 
                                 CarName = c.Description, 
                                 BrandName = b.Name, 
                                 ColorName = r.Name, 
                                 DailyPrice = c.DailyPrice 
                             };
                return result.ToList();
            }
        }
    }
}
