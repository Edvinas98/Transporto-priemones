using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportoPriemones.Core.Contracts;
using TransportoPriemones.Core.Models;

namespace TransportoPriemones.EntryPoint.Services
{
    public class MenuUI
    {
        private IVehicleService _vehicleService;
        public MenuUI(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task LaunchMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Show all vehicles");
                Console.WriteLine("2. Add a vehicle");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                GetInput(out string choice);
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        List<Vehicle> vehicles = await _vehicleService.GetAllVehicles();
                        if (vehicles.Count == 0)
                        {
                            Console.WriteLine("There are no vehicles in the list");
                            break;
                        }
                        foreach (Vehicle vehicle in vehicles)
                        {
                            Console.WriteLine(vehicle);
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        Console.Write("Enter if this vehicle is a lorry (true/false): ");
                        GetInput(out bool bLorry);
                        Console.Write("Enter vehicle maker: ");
                        GetInput(out string maker);
                        Console.Write("Enter vehicle model: ");
                        GetInput(out string model);
                        Console.Write("Enter date of manufacture: ");
                        GetInput(out DateOnly year);
                        if (bLorry)
                        {
                            Console.Write("Enter max load (Kg): ");
                            GetInput(out float maxload);
                            Console.WriteLine();
                            Console.WriteLine(await _vehicleService.AddVehicle(new Lorry(0, maxload, maker, model, year)));
                        }
                        else
                        {
                            Console.Write("Enter door count: ");
                            GetInput(out byte doorCount);
                            Console.WriteLine();
                            Console.WriteLine(await _vehicleService.AddVehicle(new Car(0, doorCount, maker, model, year)));
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Wrong input.");
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine();
            }
        }

        public static void GetInput(out string input)
        {
            while (true)
            {
                input = Console.ReadLine() ?? string.Empty;
                if (input != "")
                    return;
                else
                    Console.Write("Error, try again: ");
            }
        }

        public static void GetInput(out bool input)
        {
            while (true)
            {
                if (!bool.TryParse(Console.ReadLine(), out input))
                    Console.Write("Error, try again: ");
                else
                    return;
            }
        }

        public static void GetInput(out float input)
        {
            while (true)
            {
                if (!float.TryParse(Console.ReadLine(), out input) || input <= 0)
                    Console.Write("Error, try again: ");
                else
                    return;
            }
        }

        public static void GetInput(out DateOnly input)
        {
            while (true)
            {
                if (!DateOnly.TryParse(Console.ReadLine(), out input))
                    Console.Write("Error, try again: ");
                else
                    return;
            }
        }

        public static void GetInput(out byte input)
        {
            while (true)
            {
                if (!byte.TryParse(Console.ReadLine(), out input) || input <= 0)
                    Console.Write("Error, try again: ");
                else
                    return;
            }
        }
    }
}
