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
    public class Create : PageModel
    {
        private readonly RazorPagesDbContext _context;
        public Create(RazorPagesDbContext context)
        {
            _context = context;
        }
        public Models.Student item;
        
        public void OnGetAsync()
        {
            
        }
        public async Task<IActionResult> OnPostAsync(string FirstName, string LastName, double GPA)
        {
            if (FirstName.Length <= 1 || LastName.Length <= 1) return Redirect("/Student");
            item = new Models.Student();
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.GPA = GPA;
            _context.Students.Add(item);
            await _context.SaveChangesAsync();
            return Redirect("/Student");
        }
    }
}