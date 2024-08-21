using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportoPriemones.Core.Contracts;
using TransportoPriemones.Core.Models;

namespace TransportoPriemones.Core.Repositories
{
    public class VehicleDbRepository : IVehicleDbRepository
    {
        public async Task<List<Car>> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            using (var context = new MyDbContext())
            {
                cars = await context.Cars.ToListAsync();
            }
            return cars;
        }

        public async Task<List<Lorry>> GetAllLorries()
        {
            List<Lorry> lorries = new List<Lorry>();
            using (var context = new MyDbContext())
            {
                lorries = await context.Lorries.ToListAsync();
            }
            return lorries;
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            if (vehicle is Car)
                return await AddCar((Car)vehicle);
            else
                return await AddLorry((Lorry)vehicle);
        }

        private async Task<Vehicle> AddCar(Car car)
        {
            using (var context = new MyDbContext())
            {
                await context.Cars.AddAsync(car);
                context.SaveChanges();
            }
            return car;
        }

        private async Task<Vehicle> AddLorry(Lorry lorry)
        {
            using (var context = new MyDbContext())
            {
                await context.Lorries.AddAsync(lorry);
                context.SaveChanges();
            }
            return lorry;
        }
    }
}
