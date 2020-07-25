using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rolemanagement.Models;

namespace HotelManager.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CustomerContext _context;

        public BookingsController(CustomerContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var customerContext = _context.Booking.Include(b => b.Customer);
            return View(await customerContext.ToListAsync());
        }
        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookingNumber == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
        [Authorize(Roles = "Admin, User1, User2")]

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            ViewData["RoomNumber"] = new SelectList(_context.Room, "RoomNumber", "RoomNumber");

            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingNumber,CustomerId,RoomNumber,CheckIn,CheckOut,NumberofPersons,BookingTime")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", booking.CustomerId);
            ViewData["RoomNumber"] = new SelectList(_context.Room, "RoomNumber", "RoomNumber", booking.RoomNumber);

            return View(booking);
        }
        [Authorize(Roles = "Admin, User1, User2")]

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", booking.CustomerId);
            ViewData["RoomNumber"] = new SelectList(_context.Room, "RoomNumber", "RoomNumber", booking.RoomNumber);

            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingNumber,CustomerId,RoomNumber,CheckIn,CheckOut,NumberofPersons,BookingTime")] Booking booking)
        {
            if (id != booking.BookingNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingNumber))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", booking.CustomerId);
            ViewData["RoomNumber"] = new SelectList(_context.Room, "RoomNumber", "RoomNumber", booking.RoomNumber);

            return View(booking);
        }
        [Authorize(Roles = "Admin, User1, User2")]

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookingNumber == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingNumber == id);
        }
    }
}
