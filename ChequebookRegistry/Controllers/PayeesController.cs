using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChequebookRegistry.Data;
using ChequebookRegistry.Models;

namespace ChequebookRegistry.Controllers
{
    public class PayeesController : Controller
    {
        private readonly ChequebookRegistryContext _context;

        public PayeesController(ChequebookRegistryContext context)
        {
            _context = context;
        }

        // GET: Payees
        public async Task<IActionResult> Index()
        {
              return _context.Payees != null ? 
                          View(await _context.Payees.ToListAsync()) :
                          Problem("Entity set 'ChequebookRegistryContext.Payees'  is null.");
        }

        // GET: Payees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Payees == null)
            {
                return NotFound();
            }

            var payees = await _context.Payees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (payees == null)
            {
                return NotFound();
            }

            return View(payees);
        }

        // GET: Payees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PayeeName,ContactPerson,Telephone,Mobile,TotalAmount")] Payees payees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payees);
        }

        // GET: Payees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Payees == null)
            {
                return NotFound();
            }

            var payees = await _context.Payees.FindAsync(id);
            if (payees == null)
            {
                return NotFound();
            }
            return View(payees);
        }

        // POST: Payees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PayeeName,ContactPerson,Telephone,Mobile,TotalAmount")] Payees payees)
        {
            if (id != payees.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayeesExists(payees.ID))
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
            return View(payees);
        }

        // GET: Payees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Payees == null)
            {
                return NotFound();
            }

            var payees = await _context.Payees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (payees == null)
            {
                return NotFound();
            }

            return View(payees);
        }

        // POST: Payees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Payees == null)
            {
                return Problem("Entity set 'ChequebookRegistryContext.Payees'  is null.");
            }
            var payees = await _context.Payees.FindAsync(id);
            if (payees != null)
            {
                _context.Payees.Remove(payees);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayeesExists(int id)
        {
          return (_context.Payees?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
