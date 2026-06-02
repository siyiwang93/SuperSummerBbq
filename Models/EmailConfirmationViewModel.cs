namespace SuperSummerBbq.Models;

public class EmailConfirmationViewModel
{
    public Registration Registration { get; set; } = new();
    public EventSettings Event { get; set; } = new();
    public string SimulatedEmailBody { get; set; } = string.Empty;
}