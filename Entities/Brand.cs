using Core.Entities;
using System;
namespace Entities
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand()
        {
        }
    }
}
