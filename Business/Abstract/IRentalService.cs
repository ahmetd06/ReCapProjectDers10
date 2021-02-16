using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IResult Add(Rental x);
        IResult Update(Rental x);
        IResult Delete(Rental x);
        IResult CheckReturnDate(int carId);
        IResult RentACar(Car car, Customer customer);
        IDataResult<List<RentDetailDto>> GetRentDetailList();
    }
}
