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
    public class Delete : PageModel
    {
        private readonly RazorPagesDbContext _context;
        public Delete(RazorPagesDbContext context)
        {
            _context = context;
        }
        public int current_id;
        public Models.Student item;
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            current_id = id;
            item = await _context.Students.FindAsync(id);
            _context.Students.Remove(item);
            await _context.SaveChangesAsync();
            return Redirect("/Student");
        }
    }
}