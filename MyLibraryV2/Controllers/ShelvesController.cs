using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibraryV2.Data;
using MyLibraryV2.Models;

namespace MyLibraryV2.Controllers
{
    public class ShelvesController : Controller
    {
        private readonly MyLibraryV2Context _context;

        public ShelvesController(MyLibraryV2Context context)
        {
            _context = context;
        }

        // GET: Shelves
        public async Task<IActionResult> Index(int? id)
        {

            if (id == null)
            {
                var myLibraryV2Context1 = _context.Shelf;
                return View(await myLibraryV2Context1.ToListAsync());
            }
            var myLibraryV2Context = _context.Shelf.Where(s => s.LibraryId == id);
            return View(await myLibraryV2Context.ToListAsync());
        }

        

        // GET: Shelves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelf = await _context.Shelf
                .Include(s => s.Library)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shelf == null)
            {
                return NotFound();
            }

            return View(shelf);
        }

        // GET: Shelves/Create
        public IActionResult Create()
        {
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Id");
            return View();
        }

        // POST: Shelves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Hight,Width,LibraryId")] Shelf shelf)
        {
             var  shelfId = _context.Shelf
                 .Where(s => s.LibraryId == shelf.LibraryId)
                 .Select(s => (int?)s.ShelfId)  
                 .DefaultIfEmpty()              
                 .Max();
            shelf.LeftSpace = shelf.Width;
            if (shelfId == null)
            {
                shelf.ShelfId = 1;
            }
            else
            {
                shelf.ShelfId = Convert.ToInt32(shelfId) + 1;
            }
            if (ModelState.IsValid)
            {
                _context.Add(shelf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Id", shelf.LibraryId);
            return View(shelf);
        }

        // GET: Shelves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelf = await _context.Shelf.FindAsync(id);
            if (shelf == null)
            {
                return NotFound();
            }
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Id", shelf.LibraryId);
            return View(shelf);
        }

        // POST: Shelves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShelfId,Hight,Width,LibraryId")] Shelf shelf)
        {
            if (id != shelf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelfExists(shelf.Id))
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
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Id", shelf.LibraryId);
            return View(shelf);
        }

        // GET: Shelves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelf = await _context.Shelf
                .Include(s => s.Library)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shelf == null)
            {
                return NotFound();
            }

            return View(shelf);
        }

        // POST: Shelves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shelf = await _context.Shelf.FindAsync(id);
            if (shelf != null)
            {
                _context.Shelf.Remove(shelf);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelfExists(int id)
        {
            return _context.Shelf.Any(e => e.Id == id);
        }

        public async Task<List<Shelf>> GetShelfByAsync(Expression<Func<Shelf, bool>> predicate) =>
            await _context.Shelf.Where(predicate).ToListAsync();
    }
}
