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
    public class Details : PageModel
    {
        private readonly RazorPagesDbContext _context;
        public Details(RazorPagesDbContext context)
        {
            _context = context;
        }

        public IList<Models.Student> Students;
        public Models.Student item;
        public async Task OnGetAsync(int id)
        {
            Students = await _context.Students.ToListAsync();
            item = await _context.Students.FindAsync(id);
        }
    }
}