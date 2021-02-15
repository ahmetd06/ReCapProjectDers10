using Core.Entities;
using System;
namespace Entities
{
    public class Color:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Color()
        {
        }
    }
}
