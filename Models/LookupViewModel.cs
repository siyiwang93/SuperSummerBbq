using System.ComponentModel.DataAnnotations;

namespace SuperSummerBbq.Models;

public class LookupViewModel
{
    [Required(ErrorMessage = "Employee ID is required.")]
    [Display(Name = "Employee ID")]
    public string EmployeeId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}