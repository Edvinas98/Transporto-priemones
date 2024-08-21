using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportoPriemones.Core.Contracts;
using TransportoPriemones.Core.Repositories;
using TransportoPriemones.Core.Services;
using TransportoPriemones.EntryPoint.Services;

namespace TransportoPriemones.EntryPoint
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IVehicleDbRepository vehicleDbRepository = new VehicleDbRepository();
            IVehicleService vehicleService = new VehicleService(vehicleDbRepository);
            MenuUI menu = new MenuUI(vehicleService);
            await menu.LaunchMenu();
        }
    }
}
