using System;
using System.Collections.Generic;
using System.Linq;
using RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RazorPages.Data;

namespace RazorPages.Pages.Student
{
    
    public class IndexModel : PageModel
    {
        bool isLike(string source, string comparator)
        {
            if (comparator == null) return true;
            if (source == null || source.Length < comparator.Length) return false;
            string s = source.ToLower();
            string c = comparator.ToLower();
            for (int i = 0; i < comparator.Length; i++)
            {
                if (s[i] != c[i]) return false;
            }
            return true;
        }

        private readonly RazorPagesDbContext _context;
        public IndexModel(RazorPagesDbContext context)
        {
            _context = context;
        }

        public string msg = "";
        [BindProperty]
        public string NameFilter { get; set; }
        [BindProperty]
        public string LastNameFilter { get; set; }

        public IEnumerable<Models.Student> Students;
        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
            
        }
        public async Task OnPostAsync(double filter, string filtType)
        {
            msg = "Searching: "+NameFilter+" "+LastNameFilter;
            Students = await _context.Students.ToListAsync();
            if (filtType == "0") Students = Students.Where(s => s.GPA <= filter);
            else Students = Students.Where(s => s.GPA >= filter);
            Students = Students.Where(s => isLike(s.FirstName, NameFilter));
            Students = Students.Where(s => isLike(s.LastName, LastNameFilter));
        }
    }
}