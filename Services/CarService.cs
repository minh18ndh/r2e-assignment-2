using System.Globalization;
using MyNextCarApp.Models;

namespace MyNextCarApp.Services
{
    public class CarService
    {
        private string? _make;
        private string? _model;
        private int _year;
        private DateTime _lastMaintenanceDate, _refuelOrChargeDate;

        public string GetCarMake()
        {
            while (true)
            {
                Console.Write("Enter car make: ");
                _make = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(_make))
                {
                    break;
                }
                Console.WriteLine("Invalid input! Make must not be blank.");
            }

            return _make;
        }

        public string GetCarModel()
        {
            while (true)
            {
                Console.Write("Enter car model: ");
                _model = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(_model))
                {
                    break;
                }
                Console.WriteLine("Invalid input! Model must not be blank.");
            }

            return _model;
        }

        public int GetCarYear()
        {
            while (true)
            {
                Console.Write("Enter car year (e.g., 2020): ");
                if (int.TryParse(Console.ReadLine(), out _year) && _year >= 1886 && _year <= DateTime.Now.Year)
                {
                    break;
                }
                Console.WriteLine($"Invalid year! Please enter a valid year between 1886 and {DateTime.Now.Year}.");
            }

            return _year;
        }

        public DateTime GetCarLastMaintenanceDate()
        {
            while (true)
            {
                Console.Write("Enter last maintenance date (yyyy-MM-dd): ");
                if (ValidateLastMaintenanceDate(Console.ReadLine()))
                {
                    break;
                }
                Console.WriteLine("Invalid date format or logic! Ensure it's after the car's manufacturing year and not in the future.");
            }

            return _lastMaintenanceDate;
        }

        public Car GetCarType(string make, string model, int year, DateTime lastMaintenanceDate)
        {
            while (true)
            {
                Console.Write("Is this a FuelCar or ElectricCar? (F/E): ");
                if (char.TryParse(Console.ReadLine()?.Trim().ToUpper(), out char carType) && (carType == 'F' || carType == 'E'))
                {
                    if (carType == 'F')
                    {
                        return new FuelCar { Make = make, Model = model, Year = year, LastMaintenanceDate = lastMaintenanceDate };
                    }
                    else
                    {
                        return new ElectricCar { Make = make, Model = model, Year = year, LastMaintenanceDate = lastMaintenanceDate };
                    }
                }
                Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar.");
            }
        }

        public void HandleRefuelOrCharge(Car car)
        {
            while (true)
            {
                Console.Write("\nDo you want to refuel/charge? (Y/N): ");
                string input = Console.ReadLine()?.Trim().ToUpper() ?? "";

                if (input == "Y")
                {
                    break;
                }
                else if (input == "N")
                {
                    return;
                }
                Console.WriteLine("Invalid input! Please enter 'Y' for Yes or 'N' for No.");
            }

            while (true)
            {
                Console.Write("Enter refuel/charge date and time (yyyy-MM-dd HH:mm): ");
                if (ValidateRefuelOrChargeDate(Console.ReadLine()))
                {
                    break;
                }
                Console.WriteLine("Invalid date format or logic! Ensure it's in the future.");
            }

            switch (car)
            {
                case FuelCar fuelCar: fuelCar.Refuel(_refuelOrChargeDate); break;
                case ElectricCar electricCar: electricCar.Charge(_refuelOrChargeDate); break;
            }
        }

        private bool ValidateLastMaintenanceDate(string? input)
        {
            return DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, 
                DateTimeStyles.AllowWhiteSpaces, out _lastMaintenanceDate) 
                && _lastMaintenanceDate.Year >= _year && _lastMaintenanceDate <= DateTime.Today;
        }

        private bool ValidateRefuelOrChargeDate(string? input)
        {
            return DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, 
                DateTimeStyles.AllowWhiteSpaces, out _refuelOrChargeDate) 
                && _refuelOrChargeDate >= DateTime.Now;
        }
    }
}