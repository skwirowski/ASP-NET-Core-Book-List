using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Book> BookList { get; set; }

        public async Task OnGet()
        {
            BookList = await _applicationDbContext.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            Book persisted = await _applicationDbContext.Book.FindAsync(id);

            if (persisted == null)
            {
                return NotFound();
            }
            _applicationDbContext.Remove(persisted);

            await _applicationDbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
