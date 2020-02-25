using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }

        public string DateSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }


        public IList<Scripture> Scripture { get;set; }

        // [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Title { get; set; }
        // [BindProperty(SupportsGet = true)]
        public string ScriputerTitle { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> titleQuery = from m in _context.Scriptures
                                            orderby m.Title
                                            select m.Title;
            //Scripture = await _context.Scriptures.ToListAsync();
            var scriptures = from m in _context.Scriptures
                         select m;
            //Sorting
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";



            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ScriputerTitle))
            {
                scriptures = scriptures.Where(x => x.Title == ScriputerTitle);
            }

            if (!string.IsNullOrEmpty(sortOrder)) {
                switch (sortOrder)
                {
                    case "name_desc":
                        scriptures = scriptures.OrderByDescending(s => s.Title);
                        break;
                    case "Date":
                        scriptures = scriptures.OrderBy(s => s.DateAdded);
                        break;
                    case "date_desc":
                        scriptures = scriptures.OrderByDescending(s => s.Book);
                        break;
                    default:
                        scriptures = scriptures.OrderBy(s => s.Chapters);
                        break;
                }
            }

            Scripture = await scriptures.ToListAsync();

            //Title = new SelectList(await titleQuery.Distinct().ToListAsync());

        }
    }
}
