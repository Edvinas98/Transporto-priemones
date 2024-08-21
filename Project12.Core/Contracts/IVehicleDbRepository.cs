using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportoPriemones.Core.Models;
using TransportoPriemones.Core.Repositories;

namespace TransportoPriemones.Core.Contracts
{
    public interface IVehicleDbRepository
    {
        Task<List<Car>> GetAllCars();
        Task<List<Lorry>> GetAllLorries();
        Task<Vehicle> AddVehicle(Vehicle vehicle);
    }
}
