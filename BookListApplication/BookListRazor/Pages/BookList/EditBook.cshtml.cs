using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class EditBookModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EditBookModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _applicationDbContext.Book.FindAsync(id);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Book persisted = await _applicationDbContext.Book.FindAsync(Book.Id);
                persisted.Name = Book.Name;
                persisted.Author = Book.Author;
                persisted.ISBN = Book.ISBN;

                await _applicationDbContext.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
