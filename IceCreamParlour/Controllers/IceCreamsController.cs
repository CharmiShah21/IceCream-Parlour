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
    public class IceCreamsController : Controller
    {
        private readonly ParlourContext _context;

        public IceCreamsController(ParlourContext context)
        {
            _context = context;
        }

        // GET: IceCreams
        public async Task<IActionResult> Index()
        {
            var parlourContext = _context.IceCreams.Include(i => i.Brand).Include(i => i.Category).Include(i => i.Distributor).Include(i => i.Flavour);
            return View(await parlourContext.ToListAsync());
        }

        // GET: IceCreams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCream = await _context.IceCreams
                .Include(i => i.Brand)
                .Include(i => i.Category)
                .Include(i => i.Distributor)
                .Include(i => i.Flavour)
                .FirstOrDefaultAsync(m => m.IceCreamId == id);
            if (iceCream == null)
            {
                return NotFound();
            }

            return View(iceCream);
        }

        // GET: IceCreams/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandId");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["DistributorId"] = new SelectList(_context.Distributors, "DistributorId", "DistributorId");
            ViewData["FlavourId"] = new SelectList(_context.Flavours, "FlavourId", "FlavourId");
            return View();
        }

        // POST: IceCreams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IceCreamId,IceCreamName,IceCreamDescription,IceCreamPrice,BrandId,FlavourId,DistributorId,CategoryId")] IceCream iceCream)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iceCream);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandId", iceCream.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", iceCream.CategoryId);
            ViewData["DistributorId"] = new SelectList(_context.Distributors, "DistributorId", "DistributorId", iceCream.DistributorId);
            ViewData["FlavourId"] = new SelectList(_context.Flavours, "FlavourId", "FlavourId", iceCream.FlavourId);
            return View(iceCream);
        }

        // GET: IceCreams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCream = await _context.IceCreams.FindAsync(id);
            if (iceCream == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandId", iceCream.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", iceCream.CategoryId);
            ViewData["DistributorId"] = new SelectList(_context.Distributors, "DistributorId", "DistributorId", iceCream.DistributorId);
            ViewData["FlavourId"] = new SelectList(_context.Flavours, "FlavourId", "FlavourId", iceCream.FlavourId);
            return View(iceCream);
        }

        // POST: IceCreams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IceCreamId,IceCreamName,IceCreamDescription,IceCreamPrice,BrandId,FlavourId,DistributorId,CategoryId")] IceCream iceCream)
        {
            if (id != iceCream.IceCreamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iceCream);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IceCreamExists(iceCream.IceCreamId))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandId", iceCream.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", iceCream.CategoryId);
            ViewData["DistributorId"] = new SelectList(_context.Distributors, "DistributorId", "DistributorId", iceCream.DistributorId);
            ViewData["FlavourId"] = new SelectList(_context.Flavours, "FlavourId", "FlavourId", iceCream.FlavourId);
            return View(iceCream);
        }

        // GET: IceCreams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCream = await _context.IceCreams
                .Include(i => i.Brand)
                .Include(i => i.Category)
                .Include(i => i.Distributor)
                .Include(i => i.Flavour)
                .FirstOrDefaultAsync(m => m.IceCreamId == id);
            if (iceCream == null)
            {
                return NotFound();
            }

            return View(iceCream);
        }

        // POST: IceCreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iceCream = await _context.IceCreams.FindAsync(id);
            _context.IceCreams.Remove(iceCream);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IceCreamExists(int id)
        {
            return _context.IceCreams.Any(e => e.IceCreamId == id);
        }
    }
}
