using System.ComponentModel.DataAnnotations;

namespace chloew.Models;

public class Registration
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Department { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string EmployeeId { get; set; } = string.Empty;

    [Required, MaxLength(200), EmailAddress]
    public string Email { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? DietaryPreferences { get; set; }

    public bool ShuttleToVenue { get; set; }

    public bool ShuttleBack { get; set; }

    public bool BringingGuest { get; set; }

    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public bool IsCancelled { get; set; }

    public Guid ConfirmationToken { get; set; } = Guid.NewGuid();
}