using MyNextCarApp.Interfaces;

namespace MyNextCarApp.Models
{
    class ElectricCar : Car, IChargeable
    {
        public void Charge(DateTime timeOfCharge)
        {
            Console.WriteLine($"ElectricCar {Make} {Model} charged on {timeOfCharge:yyyy-MM-dd HH:mm}");
        }
    }
}