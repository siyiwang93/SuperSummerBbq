namespace chloew.Models;

public class EventSettings
{
    public const string SectionName = "Event";

    public string Name { get; set; } = "Super Summer BBQ 2026";
    public DateTime Date { get; set; } = new DateTime(2026, 7, 10, 11, 0, 0);
    public string Location { get; set; } = "Parking area between BV Campus Building 3 and Building 8 warehouses";
    public string Type { get; set; } = "Free annual internal company event";
    public string AdminKey { get; set; } = "bbq-admin-2026";
}