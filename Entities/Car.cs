using Core.Entities;
using System;
namespace Entities
{
    public class Car:IEntity
    {
        public Car()
        {
        }
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        
    }
}
