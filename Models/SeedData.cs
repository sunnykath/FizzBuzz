using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzz.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FizzBuzzContext (
                serviceProvider.GetRequiredService<
                    DbContextOptions<FizzBuzzContext>>()))
            {
                // Look for any movies.
                if (context.CustomNumber.Any())
                {
                    return;   // DB has been seeded
                }


                for (int i = 1; i <= 100; i++)
                {
                    string value = "";

                    if (i % 3 == 0)       // Multiple of 3
                    {
                        value = value + "Fizz";

                    }
                    if (i % 5 == 0)       // Multiple of 5
                    {
                        value = value + "Buzz";

                    } 
                    if (value == "")
                    {
                        value = i.ToString();

                    }

                    context.CustomNumber.Add(new CustomNumber { value = value, number = i });
                }

                context.SaveChanges();
            }
        }
    }
}
