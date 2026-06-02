using System.ComponentModel.DataAnnotations;

namespace SuperSummerBbq.Models;

public class AdminLoginViewModel
{
    [Required(ErrorMessage = "Admin access key is required.")]
    [Display(Name = "Admin Access Key")]
    [DataType(DataType.Password)]
    public string AccessKey { get; set; } = string.Empty;
}