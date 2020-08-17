using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookListRazor.Pages.BookList
{
    public class CreateBookModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CreateBookModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _applicationDbContext.Book.AddAsync(Book);
                await _applicationDbContext.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
