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
    public class ModeleDeVoituresController : Controller
    {
        private readonly YourDbContext _context;

        public ModeleDeVoituresController(YourDbContext context)
        {
            _context = context;
        }

        // GET: ModeleDeVoitures
        public async Task<IActionResult> Index()
        {
              return _context.ModelesDeVoiture != null ? 
                          View(await _context.ModelesDeVoiture.ToListAsync()) :
                          Problem("Entity set 'YourDbContext.ModelesDeVoiture'  is null.");
        }

        // GET: ModeleDeVoitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelesDeVoiture == null)
            {
                return NotFound();
            }

            var modeleDeVoiture = await _context.ModelesDeVoiture
                .FirstOrDefaultAsync(m => m.IdModele == id);
            if (modeleDeVoiture == null)
            {
                return NotFound();
            }

            return View(modeleDeVoiture);
        }

        // GET: ModeleDeVoitures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModeleDeVoitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("IdModele,Marque,Modele,Annee")] ModeleDeVoiture modeleDeVoiture)
        {
            if (file != null)
            {
                string filename = file.FileName;
                //  string  ext = Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images"));
                using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                { await file.CopyToAsync(filestream); }

                modeleDeVoiture.img = filename;
            }


            _context.Add(modeleDeVoiture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: ModeleDeVoitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelesDeVoiture == null)
            {
                return NotFound();
            }

            var modeleDeVoiture = await _context.ModelesDeVoiture.FindAsync(id);
            if (modeleDeVoiture == null)
            {
                return NotFound();
            }
            return View(modeleDeVoiture);
        }

        // POST: ModeleDeVoitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file ,int id, [Bind("IdModele,Marque,Modele,Annee,img")] ModeleDeVoiture modeleDeVoiture)
        {
            if (file != null)
            {
                string filename = file.FileName;
                //  string  ext = Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images"));
                using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                { await file.CopyToAsync(filestream); }

                modeleDeVoiture.img = filename;
            }
            _context.Update(modeleDeVoiture);
                    await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
          
        }

        // GET: ModeleDeVoitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelesDeVoiture == null)
            {
                return NotFound();
            }

            var modeleDeVoiture = await _context.ModelesDeVoiture
                .FirstOrDefaultAsync(m => m.IdModele == id);
            if (modeleDeVoiture == null)
            {
                return NotFound();
            }

            return View(modeleDeVoiture);
        }

        // POST: ModeleDeVoitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelesDeVoiture == null)
            {
                return Problem("Entity set 'YourDbContext.ModelesDeVoiture'  is null.");
            }
            var modeleDeVoiture = await _context.ModelesDeVoiture.FindAsync(id);
            if (modeleDeVoiture != null)
            {
                _context.ModelesDeVoiture.Remove(modeleDeVoiture);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeleDeVoitureExists(int id)
        {
          return (_context.ModelesDeVoiture?.Any(e => e.IdModele == id)).GetValueOrDefault();
        }
    }
}
