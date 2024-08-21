using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportoPriemones.Core.Models;
using TransportoPriemones.Core.Repositories;

namespace TransportoPriemones.Core.Contracts
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAllVehicles();
        Task<Vehicle> AddVehicle(Vehicle vehicle);
    }
}
