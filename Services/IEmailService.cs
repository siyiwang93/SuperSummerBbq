using SuperSummerBbq.Models;

namespace SuperSummerBbq.Services;

public interface IEmailService
{
    string BuildConfirmationBody(Registration registration, EventSettings eventSettings);
    Task SendConfirmationAsync(Registration registration, EventSettings eventSettings, CancellationToken ct = default);
}