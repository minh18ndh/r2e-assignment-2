using MyNextCarApp.Services;
using MyNextCarApp.Models;

namespace MyNextCarApp
{
    class Program
    {  
        private static readonly CarService carService = new();

        static void Main()
        {
            string make = carService.GetCarMake();
            string model = carService.GetCarModel();
            int year = carService.GetCarYear();
            DateTime lastMaintenanceDate = carService.GetCarLastMaintenanceDate();

            Car car = carService.GetCarType(make, model, year, lastMaintenanceDate);

            car.DisplayDetails();
            car.ScheduleMaintenance();

            carService.HandleRefuelOrCharge(car);
        }
    }
}