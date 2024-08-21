using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportoPriemones.Core.Models
{
    public class Lorry : Vehicle
    {
        public float MaxLoad { get; set; }

        public Lorry(int id, float maxLoad, string maker, string model, DateOnly year) : base(id, maker, model, year)
        {
            MaxLoad = Convert.ToSingle(Math.Floor(maxLoad * 10.0) * 0.1);
        }

        public Lorry() : base()
        {
            MaxLoad = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nMax load: {MaxLoad} Kg";
        }
    }
}
