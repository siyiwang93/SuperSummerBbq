namespace chloew.Models;

public class AdminDashboardViewModel
{
    public int TotalActive { get; set; }
    public int TotalCancelled { get; set; }
    public int ShuttleToCount { get; set; }
    public int ShuttleBackCount { get; set; }
    public int GuestCount { get; set; }
    public List<Registration> Registrations { get; set; } = [];
    public Dictionary<string, int> DepartmentBreakdown { get; set; } = new();
}