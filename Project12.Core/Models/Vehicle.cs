using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TransportoPriemones.Core.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Maker {  get; set; }
        public string Model { get; set; }
        public DateOnly Year { get; set; }

        public Vehicle(int id, string maker, string model, DateOnly year)
        {
            Id = id;
            Maker = maker;
            Model = model;
            Year = year;
        }
        public Vehicle() 
        {
            Id = 0;
            Maker = "";
            Model = "";
            Year = DateOnly.Parse("1900-01-01");
        }

        public override string ToString()
        {
            return $"Maker: {Maker}".PadRight(20) + $"Model: {Model}".PadRight(20) + $"Manufacture date: {Year}";
        }
    }
}
