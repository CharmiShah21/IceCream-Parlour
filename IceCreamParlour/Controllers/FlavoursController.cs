using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceCreamParlour.Models;

namespace IceCreamParlour.Controllers
{
    public class FlavoursController : Controller
    {
        private readonly ParlourContext _context;

        public FlavoursController(ParlourContext context)
        {
            _context = context;
        }

        // GET: Flavours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flavours.ToListAsync());
        }

        // GET: Flavours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavour = await _context.Flavours
                .FirstOrDefaultAsync(m => m.FlavourId == id);
            if (flavour == null)
            {
                return NotFound();
            }

            return View(flavour);
        }

        // GET: Flavours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flavours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlavourId,FlavourName,FlavourDescription")] Flavour flavour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flavour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flavour);
        }

        // GET: Flavours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavour = await _context.Flavours.FindAsync(id);
            if (flavour == null)
            {
                return NotFound();
            }
            return View(flavour);
        }

        // POST: Flavours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlavourId,FlavourName,FlavourDescription")] Flavour flavour)
        {
            if (id != flavour.FlavourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flavour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlavourExists(flavour.FlavourId))
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
            return View(flavour);
        }

        // GET: Flavours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavour = await _context.Flavours
                .FirstOrDefaultAsync(m => m.FlavourId == id);
            if (flavour == null)
            {
                return NotFound();
            }

            return View(flavour);
        }

        // POST: Flavours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flavour = await _context.Flavours.FindAsync(id);
            _context.Flavours.Remove(flavour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlavourExists(int id)
        {
            return _context.Flavours.Any(e => e.FlavourId == id);
        }
    }
}
