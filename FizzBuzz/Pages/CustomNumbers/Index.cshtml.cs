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
    public class IndexModel : PageModel
    {
        private readonly FizzBuzz.Data.FizzBuzzContext _context;

        public IndexModel(FizzBuzz.Data.FizzBuzzContext context)
        {
            _context = context;
        }

        public IList<CustomNumber> CustomNumber { get;set; }

        public async Task OnGetAsync()
        {
            CustomNumber = await _context.CustomNumber.ToListAsync();
            CustomNumber = CustomNumber.OrderBy(i => i.number).ToList();
        }
    }
}
