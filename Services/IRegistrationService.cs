using chloew.Models;

namespace chloew.Services;

public interface IRegistrationService
{
    Task<Registration?> GetActiveByEmployeeIdAsync(string employeeId, CancellationToken ct = default);
    Task<Registration?> GetActiveByCredentialsAsync(string employeeId, string email, CancellationToken ct = default);
    Task<Registration?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<(bool Success, Registration? Registration, string? Error)> CreateAsync(RegistrationFormViewModel model, CancellationToken ct = default);
    Task<(bool Success, string? Error)> UpdateAsync(int id, RegistrationFormViewModel model, CancellationToken ct = default);
    Task<bool> CancelAsync(int id, CancellationToken ct = default);
    Task<int> GetActiveCountAsync(CancellationToken ct = default);
    Task<AdminDashboardViewModel> GetAdminDashboardAsync(CancellationToken ct = default);
}