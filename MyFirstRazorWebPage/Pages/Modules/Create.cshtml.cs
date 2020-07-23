using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstRazorWebPage.Models;

namespace MyFirstRazorWebPage.Pages.Modules
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Module Module { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Module.Add(Module);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}