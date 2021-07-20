using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        /// <summary>
        /// Gets the books saved in the database
        /// </summary>
        /// <returns>The list of books saved in the database</returns>
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        /// <summary>
        /// Delete handler
        /// </summary>
        /// <param name="id"></param>
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);

            if (book == null)
                return NotFound();

            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            // Refresh the books list
            await OnGet();

            return Page();
        }
    }
}
