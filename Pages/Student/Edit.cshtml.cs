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
    public class Edit : PageModel
    {
        private readonly RazorPagesDbContext _context;
        public Edit(RazorPagesDbContext context)
        {
            _context = context;
        }
        public int current_id;
        public Models.Student item;
        
        public async Task OnGetAsync(int id)
        {
            current_id = id;
            item = await _context.Students.FindAsync(id);
        }
        public async Task<IActionResult> OnPostAsync(int id, string FirstName, string LastName, double GPA)
        {
            current_id = id;
            item = await _context.Students.FindAsync(id);
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.GPA = GPA;
            _context.Students.Update(item);
            await _context.SaveChangesAsync();
            return Redirect("/Student");
        }
    }
}