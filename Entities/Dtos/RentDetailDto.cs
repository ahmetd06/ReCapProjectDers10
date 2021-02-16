using System;
using Core.Entities;

namespace Entities.Dtos
{
    public class RentDetailDto:IDto
    {
        public int RentId { get; set; }
        public string CarDescription { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
