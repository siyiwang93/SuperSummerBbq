using SuperSummerBbq.Models;
using SuperSummerBbq.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SuperSummerBbq.Controllers;

public class HomeController(
    ILogger<HomeController> logger,
    IRegistrationService registrationService,
    IOptions<EventSettings> eventOptions) : Controller
{
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var eventSettings = eventOptions.Value;
        var vm = new LandingPageViewModel
        {
            Event = eventSettings,
            TotalRegistrations = await registrationService.GetActiveCountAsync(ct),
            EventDateIso = eventSettings.Date.ToString("o")
        };
        return View(vm);
    }

    public IActionResult Agenda() => View();

    public IActionResult Feast() => View();

    public IActionResult Faq() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        logger.LogError("Unhandled error displayed to user.");
        return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
    }
}