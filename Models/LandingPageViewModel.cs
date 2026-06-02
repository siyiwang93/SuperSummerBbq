namespace SuperSummerBbq.Models;

public class LandingPageViewModel
{
    public EventSettings Event { get; set; } = new();
    public int TotalRegistrations { get; set; }
    public string EventDateIso { get; set; } = string.Empty;
}