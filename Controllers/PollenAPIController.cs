using Microsoft.AspNetCore.Mvc;
using Eksamen2025Gruppe5.Services;
using Eksamen2025Gruppe5.Models;

namespace Eksamen2025Gruppe5.Controllers
{
    public class PollenAPIController : Controller
    {
        private readonly GooglePollenService _pollenService;

        public PollenAPIController(GooglePollenService pollenService)
        {
            _pollenService = pollenService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _pollenService.GetPollenForecastAsync();
            return View(data);
        }
    }
}
