using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentDetailDto> GetAllRentDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join m in context.Customers on r.CustomerId equals m.Id
                             select new RentDetailDto { 
                                RentId=r.Id,
                                CarDescription = c.Description,
                                CustomerName= m.CompanyName,
                                RentDate=r.RentDate,
                                ReturnDate=r.ReturnDate
                             };
                return result.ToList();
               
            }
        }
    }
}
