using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                return null;

               
            }
        }
    }
}
