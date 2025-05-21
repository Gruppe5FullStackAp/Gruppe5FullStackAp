using Microsoft.AspNetCore.Mvc;
using Eksamen2025Gruppe5.Models;
using System.Collections.Generic;

namespace Eksamen2025Gruppe5.Controllers
{
    public class PollenAPIController : Controller
    {
        public IActionResult Index()
        {
            // Dummydata: pollenvarsel for 5 kommende dager
            var pollenVarsel = new List<PollenAPIViewModel>
            {
                new PollenAPIViewModel
                {
                    Code = "BJ",
                    DisplayName = "Bjørk",
                    Value = 5,
                    Category = "Tre",
                    IndexDescription = "Høyt nivå",
                    Color = "R:255, G:0, B:0",
                    Date = "22.05.2025"
                },
                new PollenAPIViewModel
                {
                    Code = "GR",
                    DisplayName = "Gress",
                    Value = 3,
                    Category = "Gress",
                    IndexDescription = "Moderat nivå",
                    Color = "R:255, G:255, B:0",
                    Date = "23.05.2025"
                },
                new PollenAPIViewModel
                {
                    Code = "SA",
                    DisplayName = "Salix",
                    Value = 2,
                    Category = "Tre",
                    IndexDescription = "Lavt nivå",
                    Color = "R:0, G:255, B:0",
                    Date = "24.05.2025"
                },
                new PollenAPIViewModel
                {
                    Code = "HS",
                    DisplayName = "Hassel",
                    Value = 4,
                    Category = "Tre",
                    IndexDescription = "Middels nivå",
                    Color = "R:255, G:165, B:0",
                    Date = "25.05.2025"
                },
                new PollenAPIViewModel
                {
                    Code = "OR",
                    DisplayName = "Or",
                    Value = 3,
                    Category = "Tre",
                    IndexDescription = "Moderat nivå",
                    Color = "R:255, G:255, B:0",
                    Date = "26.05.2025"
                }
            };

            return View(pollenVarsel);
        }
    }
}
