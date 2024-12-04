using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    public class BookingTypesController : Controller
    {
        private readonly RestaurantContext _context;

        public BookingTypesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: BookingTypes
        public async Task<IActionResult> Index()
        {
              return _context.BookingTypes != null ? 
                          View(await _context.BookingTypes.ToListAsync()) :
                          Problem("Entity set 'RestaurantContext.BookingTypes'  is null.");
        }

        // GET: BookingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookingTypes == null)
            {
                return NotFound();
            }

            var bookingType = await _context.BookingTypes
                .FirstOrDefaultAsync(m => m.BookingTypeId == id);
            if (bookingType == null)
            {
                return NotFound();
            }

            return View(bookingType);
        }

        // GET: BookingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingTypeId,BookingTypee,NoOfTables")] BookingType bookingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingType);
        }

        // GET: BookingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookingTypes == null)
            {
                return NotFound();
            }

            var bookingType = await _context.BookingTypes.FindAsync(id);
            if (bookingType == null)
            {
                return NotFound();
            }
            return View(bookingType);
        }

        // POST: BookingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingTypeId,BookingTypee,NoOfTables,NoOfSeats")] BookingType bookingType)
        {
            if (id != bookingType.BookingTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingTypeExists(bookingType.BookingTypeId))
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
            return View(bookingType);
        }

        // GET: BookingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookingTypes == null)
            {
                return NotFound();
            }

            var bookingType = await _context.BookingTypes
                .FirstOrDefaultAsync(m => m.BookingTypeId == id);
            if (bookingType == null)
            {
                return NotFound();
            }

            return View(bookingType);
        }

        // POST: BookingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookingTypes == null)
            {
                return Problem("Entity set 'RestaurantContext.BookingTypes'  is null.");
            }
            var bookingType = await _context.BookingTypes.FindAsync(id);
            if (bookingType != null)
            {
                _context.BookingTypes.Remove(bookingType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingTypeExists(int id)
        {
          return (_context.BookingTypes?.Any(e => e.BookingTypeId == id)).GetValueOrDefault();
        }
    }
}
