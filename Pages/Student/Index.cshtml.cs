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
        private readonly RazorPagesDbContext _context;
        public IndexModel(RazorPagesDbContext context)
        {
            _context = context;
        }

        public IList<Models.Student> Students;
        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
        }
    }
}