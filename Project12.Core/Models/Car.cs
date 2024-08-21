using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportoPriemones.Core.Models
{
    public class Car : Vehicle
    {
        public byte DoorCount { get; set; }

        public Car(int id, byte doorCount, string maker, string model, DateOnly year) : base(id, maker, model, year)
        {
            DoorCount = doorCount;
        }

        public Car() : base()
        {
            DoorCount = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nDoor count: {DoorCount}";
        }
    }
}
