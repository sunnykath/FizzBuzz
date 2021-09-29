using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Data;
using FizzBuzz.Models;

namespace FizzBuzz.Pages.CustomNumbers
{
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzz.Data.FizzBuzzContext _context;

        public DeleteModel(FizzBuzz.Data.FizzBuzzContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomNumber CustomNumber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomNumber = await _context.CustomNumber.FirstOrDefaultAsync(m => m.ID == id);

            if (CustomNumber == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomNumber = await _context.CustomNumber.FindAsync(id);

            if (CustomNumber != null)
            {
                _context.CustomNumber.Remove(CustomNumber);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
