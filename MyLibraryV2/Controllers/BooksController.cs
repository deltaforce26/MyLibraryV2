using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibraryV2.Data;
using MyLibraryV2.Models;

namespace MyLibraryV2.Controllers
{
    public class BooksController : Controller
    {
        private readonly MyLibraryV2Context _context;

        public BooksController(MyLibraryV2Context context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var myLibraryV2Context = _context.Book.Include(b => b.Shelf);
            return View(await myLibraryV2Context.ToListAsync());
        }
        


        public async Task<IActionResult> AvailableShelves(int libraryId, [Bind("BookName,Hight,Width")] Book book)
        {
            var LibraryId = libraryId;
            var availableShelves = await _context.Shelf
                .Where(s => s.LibraryId == LibraryId && s.Hight > book.Hight && s.LeftSpace > book.Width)
                .ToListAsync();
            ViewBag.book = book;
            return View(availableShelves);
        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Shelf)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create/5
        public IActionResult Create(int? Id)
        {
            ViewBag.ShelfId = new SelectList(_context.Shelf.Where(s => s.ShelfId == Id).Select(Shelf => Shelf.ShelfId).ToList());
            ViewBag.Library = new SelectList(_context.Library, "Id", "LibraryName");
            return View();
        }


        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? libraryId, [Bind("BookName,Hight,Width,ShelfNumber,Genre")] Book book)
        {
            var Shelf = await _context.Shelf
                .Where(s => s.LibraryId == libraryId && s.ShelfId == book.ShelfNumber).SingleAsync();
            if (Shelf == null)
            {
                ModelState.AddModelError("", "The selected shelf does not exist.");
            }
            else if (Shelf.LeftSpace < book.Width || Shelf.Hight < book.Hight)
            {
                ModelState.AddModelError("", "The selected shelf does not have enough space or height for the book.");
            }
            else
            {
                book.ShelfId = Shelf.Id;
                if (ModelState.IsValid)
                {
                    Shelf.LeftSpace -= book.Width;
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                } 
            }
            ViewData["ShelfId"] = new SelectList(_context.Set<Shelf>(), "Id", "Id", book.ShelfId);
            ViewData["LibraryName"] = new SelectList(_context.Library, "Id", "LibraryName", libraryId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["ShelfId"] = new SelectList(_context.Set<Shelf>(), "Id", "Id", book.ShelfId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName,Hight,Width,Genre,ShelfId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["ShelfId"] = new SelectList(_context.Set<Shelf>(), "Id", "Id", book.ShelfId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Shelf)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
