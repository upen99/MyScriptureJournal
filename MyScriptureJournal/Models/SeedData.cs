using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scriptures.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scriptures.AddRange(
                    new Scripture
                    {
                        Title = "The Book fo Nephi",
                        Book = "1ST Nephi",
                        Chapters = 3,
                        Verses = 1-5,
                        Note = "Touched My Heart",
                        DateAdded = DateTime.Parse("1989-2-12"),
                    },

                    new Scripture
                    {
                        Title = "The Book fo Nephi",
                        Book = "1ST Nephi",
                        Chapters = 3,
                        Verses = 1 - 5,
                        Note = "Touched My Heart",
                        DateAdded = DateTime.Parse("1989-2-12"),
                    },

                    new Scripture
                    {
                        Title = "The Book fo Nephi",
                        Book = "1ST Nephi",
                        Chapters = 3,
                        Verses = 1 - 5,
                        Note = "Touched My Heart",
                        DateAdded = DateTime.Parse("1989-2-12"),
                    },

                    new Scripture
                    {
                        Title = "The Book fo Nephi",
                        Book = "1ST Nephi",
                        Chapters = 3,
                        Verses = 1 - 5,
                        Note = "Touched My Heart",
                        DateAdded = DateTime.Parse("1989-2-12"),
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
