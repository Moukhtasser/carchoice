using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testPFA.Data;
using testPFA.Models;

namespace testPFA.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly YourDbContext _context;

        public ReservationsController(YourDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
              return _context.Reservations != null ? 
                          View(await _context.Reservations.ToListAsync()) :
                          Problem("Entity set 'YourDbContext.Reservations'  is null.");
        }

        // GET: Reservations/Details/5
        /* public async Task<IActionResult> Details(int? id)
         {

             if (id == null || _context.Reservations == null)
             {
                 return NotFound();
             }

             var reservation = await _context.Reservations
                 .FirstOrDefaultAsync(m => m.IdReservation == id);
             if (reservation == null)
             {
                 return NotFound();
             }

             return View(reservation);
         } */
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Voiture) // Charger les données relatives à la propriété Voiture
                //.ThenInclude(v => v.Extras) // Charger les données relatives à la propriété Extras de Voiture
                .Include(r => r.Client) // Charger les données relatives à la propriété Client
                .Include(r => r.Saison) // Charger les données relatives à la propriété Saison
                .FirstOrDefaultAsync(m => m.IdReservation == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
       /* public IActionResult Create()
        {
            return View();
        }*/
        public IActionResult Create()
        {
            // Récupérer la liste des voitures existantes dans la base de données
            var cars = _context.ModelesDeVoiture.ToList();

            // Passer la liste des voitures à la vue via ViewBag
            ViewBag.Cars = cars;

            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservation,Client,Voiture,Extras,Saison,PrixR")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReservation,Client,Voiture,Extras,Saison,PrixR")] Reservation reservation)
        {
            if (id != reservation.IdReservation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.IdReservation))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.IdReservation == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'YourDbContext.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservations?.Any(e => e.IdReservation == id)).GetValueOrDefault();
        }
    }
}
