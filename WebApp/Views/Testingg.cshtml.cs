using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Registration;
using WebApp.Data;

namespace WebApp.Views
{
    public class TestinggModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public TestinggModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RegistrationOfInterest RegistrationOfInterest { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RegistrationOfInterests.Add(RegistrationOfInterest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
