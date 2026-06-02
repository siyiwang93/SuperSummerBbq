using System.ComponentModel.DataAnnotations;

namespace SuperSummerBbq.Models;

public class RegistrationFormViewModel
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [Display(Name = "First Name")]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [Display(Name = "Last Name")]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required.")]
    [MaxLength(100)]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Employee ID is required.")]
    [Display(Name = "Employee ID")]
    [MaxLength(50)]
    public string EmployeeId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Dietary Preferences")]
    [MaxLength(500)]
    public string? DietaryPreferences { get; set; }

    [Display(Name = "Shuttle to venue")]
    public bool ShuttleToVenue { get; set; }

    [Display(Name = "Shuttle back")]
    public bool ShuttleBack { get; set; }

    [Display(Name = "Do you want to bring a guest?")]
    public bool BringingGuest { get; set; }

    public static RegistrationFormViewModel FromEntity(Registration r) => new()
    {
        Id = r.Id,
        FirstName = r.FirstName,
        LastName = r.LastName,
        Department = r.Department,
        EmployeeId = r.EmployeeId,
        Email = r.Email,
        DietaryPreferences = r.DietaryPreferences,
        ShuttleToVenue = r.ShuttleToVenue,
        ShuttleBack = r.ShuttleBack,
        BringingGuest = r.BringingGuest
    };

    public Registration ToEntity() => new()
    {
        Id = Id ?? 0,
        FirstName = FirstName.Trim(),
        LastName = LastName.Trim(),
        Department = Department.Trim(),
        EmployeeId = EmployeeId.Trim(),
        Email = Email.Trim(),
        DietaryPreferences = string.IsNullOrWhiteSpace(DietaryPreferences) ? null : DietaryPreferences.Trim(),
        ShuttleToVenue = ShuttleToVenue,
        ShuttleBack = ShuttleBack,
        BringingGuest = BringingGuest
    };
}