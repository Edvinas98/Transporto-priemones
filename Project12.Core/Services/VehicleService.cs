using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportoPriemones.Core.Contracts;
using TransportoPriemones.Core.Models;

namespace TransportoPriemones.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleDbRepository _vehicleDbRepository;

        public VehicleService(IVehicleDbRepository vehicleDbRepository)
        {
            _vehicleDbRepository = vehicleDbRepository;
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            var cars = _vehicleDbRepository.GetAllCars();
            var lorries = _vehicleDbRepository.GetAllLorries();
            await Task.WhenAll(cars, lorries);

            vehicles.AddRange(cars.Result);
            vehicles.AddRange(lorries.Result);

            return vehicles;
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            return await _vehicleDbRepository.AddVehicle(vehicle);
        }
    }
}
