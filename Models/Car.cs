namespace MyNextCarApp.Models
{
    public abstract class Car
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required int Year { get; set; }
        public required DateTime LastMaintenanceDate { get; set; }

        public void ScheduleMaintenance()
        {
            DateTime nextMaintenanceDate = LastMaintenanceDate.AddMonths(6);
            Console.WriteLine($"Next Maintenance: {nextMaintenanceDate:yyyy-MM-dd}");
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Car: {Make} {Model} {Year}");
            Console.WriteLine($"Last Maintenance: {LastMaintenanceDate:yyyy-MM-dd}");
        }
    }
}