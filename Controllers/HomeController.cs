using chloew.Models;
using chloew.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace chloew.Controllers;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        logger.LogError("Unhandled error displayed to user.");
        return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
    }
}