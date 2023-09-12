using Aula005.RazorPages.Data;
using Aula005.RazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula005.RazorPages.Pages.Events
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        public Curso Curso { get; set;  } = new();
        
        public Details(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Curso == null) {
                return NotFound();
            }   

            var eventModel =
             await _context.Curso.Include(e=>e.Players) .FirstOrDefaultAsync(e => e.EventID == id);

             if (eventModel == null) {
                return NotFound();
             }

             Curso = eventModel;
            
            return Page();
        }

    }
}