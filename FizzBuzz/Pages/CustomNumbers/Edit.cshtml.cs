using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Data;
using FizzBuzz.Models;

namespace FizzBuzz.Pages.CustomNumbers
{
    public class EditModel : PageModel
    {
        private readonly FizzBuzz.Data.FizzBuzzContext _context;

        public EditModel(FizzBuzz.Data.FizzBuzzContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomNumberExists(CustomNumber.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomNumberExists(int id)
        {
            return _context.CustomNumber.Any(e => e.ID == id);
        }
    }
}
