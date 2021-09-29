using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Models;

namespace FizzBuzz.Data
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext (DbContextOptions<FizzBuzzContext> options)
            : base(options)
        {
        }

        public DbSet<FizzBuzz.Models.CustomNumber> CustomNumber { get; set; }
    }
}
