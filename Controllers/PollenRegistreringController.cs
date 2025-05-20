using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eksamen2025Gruppe5.Models;

namespace Eksamen2025Gruppe5.Controllers
{
    public class PollenRegistreringController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PollenRegistreringController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PollenRegistrering
        public async Task<IActionResult> Index()
        {
            return View(await _context.PollenRegistreringer.ToListAsync());
        }

        // GET: PollenRegistrering/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollenRegistrering = await _context.PollenRegistreringer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pollenRegistrering == null)
            {
                return NotFound();
            }

            return View(pollenRegistrering);
        }

        // GET: PollenRegistrering/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PollenRegistrering/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dato,Område,Nivå")] PollenRegistrering pollenRegistrering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pollenRegistrering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pollenRegistrering);
        }

        // GET: PollenRegistrering/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollenRegistrering = await _context.PollenRegistreringer.FindAsync(id);
            if (pollenRegistrering == null)
            {
                return NotFound();
            }
            return View(pollenRegistrering);
        }

        // POST: PollenRegistrering/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dato,Område,Nivå")] PollenRegistrering pollenRegistrering)
        {
            if (id != pollenRegistrering.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pollenRegistrering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PollenRegistreringExists(pollenRegistrering.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pollenRegistrering);
        }

        // GET: PollenRegistrering/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollenRegistrering = await _context.PollenRegistreringer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pollenRegistrering == null)
            {
                return NotFound();
            }

            return View(pollenRegistrering);
        }

        // POST: PollenRegistrering/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pollenRegistrering = await _context.PollenRegistreringer.FindAsync(id);
            if (pollenRegistrering != null)
            {
                _context.PollenRegistreringer.Remove(pollenRegistrering);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PollenRegistreringExists(int id)
        {
            return _context.PollenRegistreringer.Any(e => e.Id == id);
        }
    }
}
