using System;
using System.Collections.Generic;
using Core.DataAccess;
using Entities;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        //bu şekilde Car sınıfı için yapılandırmış olduk
        List<CarDetailDto> GetCarDetails();
    }
}
