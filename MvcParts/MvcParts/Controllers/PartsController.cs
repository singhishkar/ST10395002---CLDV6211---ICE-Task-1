using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcParts.Data;
using MvcParts.Models;

namespace MvcParts.Controllers
{
    public class PartsController : Controller
    {
        private readonly MvcPartsContext _context;

        public PartsController(MvcPartsContext context)
        {
            _context = context;
        }

        // GET: Parts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parts.ToListAsync());
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parts = await _context.Parts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parts == null)
            {
                return NotFound();
            }

            return View(parts);
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,partManufacturer,carManufacturer,carModel,Description,Category,Quantity,Price,Location")] Parts parts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parts);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parts = await _context.Parts.FindAsync(id);
            if (parts == null)
            {
                return NotFound();
            }
            return View(parts);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,partManufacturer,carManufacturer,carModel,Description,Category,Quantity,Price,Location")] Parts parts)
        {
            if (id != parts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartsExists(parts.Id))
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
            return View(parts);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parts = await _context.Parts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parts == null)
            {
                return NotFound();
            }

            return View(parts);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parts = await _context.Parts.FindAsync(id);
            if (parts != null)
            {
                _context.Parts.Remove(parts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartsExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }
    }
}
