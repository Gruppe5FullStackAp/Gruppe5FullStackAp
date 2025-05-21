using Microsoft.AspNetCore.Mvc;
using Eksamen2025Gruppe5.Models;
using System.Collections.Generic;

namespace Eksamen2025Gruppe5.Controllers
{
    public class PollenAPIController : Controller
    {
        public IActionResult Index()
        {
            // Dette er eksempeldata. Senere skal dette byttes ut med data fra API/database.
            var pollenVarsler = new List<PollenAPIViewModel>
            {
                new PollenAPIViewModel
                {
                    Code = "BJ",
                    DisplayName = "Bjørk",
                    Value = 5,
                    Category = "Tre",
                    IndexDescription = "Høyt nivå",
                    Date = "22.05.2025",
                    Red = 255, Green = 0, Blue = 0    // Rød for høyt nivå
                },
                new PollenAPIViewModel
                {
                    Code = "GR",
                    DisplayName = "Gress",
                    Value = 3,
                    Category = "Gress",
                    IndexDescription = "Moderat nivå",
                    Date = "23.05.2025",
                    Red = 255, Green = 255, Blue = 0  // Gul for moderat nivå
                },
                // Legg til flere dager etter behov
            };

            return View(pollenVarsler);
        }
    }
}
