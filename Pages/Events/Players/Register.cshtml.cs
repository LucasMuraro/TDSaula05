using Aula005.RazorPages.Data;
using Aula005.RazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula05.RazorPages.Pages.Events.Players
{
    public class Register : PageModel
    {
        private readonly AppDbContext _context;
        public List<Curso>? CursoList { get; set; }
        public List<Curso>? AlunoList { get; set; }

        public Register(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            CursoList = await _context.Cursos!.ToListAsync();
            AlunoList = await _context.Alunos!.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int evento, int jogador)
        {
            var selectedEvent = await _context.Cursos!.Include(e => e.Aluno).FirstOrDefaultAsync(e => e.CursoId == evento);
            var selectedPlayer = await _context.Alunos!.FindAsync(jogador);

            if (selectedEvent == null || selectedPlayer == null)
            {
                return NotFound();
            }

            selectedEvent.Players!.Add(selectedPlayer);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}