using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental x)
        {
            _rentalDal.Add(x);
            return new SuccessResult();
        }

        public IResult Update(Rental x)
        {
            _rentalDal.Update(x);
            return new SuccessResult();
        }

        public IResult Delete(Rental x)
        {
            _rentalDal.Delete(x);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listelendi);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

       

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(p => p.CarId == carId && p.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult RentACar(Car car, Customer customer)
        {
            if (CheckReturnDate(car.Id) is SuccessResult)
            {
              _rentalDal.Add(new Rental { CarId = car.Id, CustomerId = customer.Id, RentDate = DateTime.Now.Date, ReturnDate = null });
                return new SuccessResult(Messages.AracKiralandı);
            }
            return new ErrorResult(Messages.AracKiralanamadı +  " : " +Messages.AracKirada);
        }

        public IDataResult<List<RentDetailDto>> GetRentDetailList()
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentalDal.GetAllRentDetails());
        }

        public IResult UpdateReturnDate(int rentId, DateTime returnDate)
        {
            Rental rental = _rentalDal.Get(p => p.Id == rentId);
            rental.ReturnDate = returnDate;
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
