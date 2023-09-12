using Aula005.RazorPages.Data;
using Aula005.RazorPages.Model;

namespace Aula005.RazorPages.Data {
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Cursos!.Any())
            {
                var events = new Curso[] {
                    new Curso{
                        NomeCurso ="Ciencia da Computação",
                        Descricao = "Curso de TI",
                        DateInicio = DateTime.Parse("2023-04-01")
                    },
                };
                context.AddRange(events);
            }

            if (!context.Alunos!.Any())
            {
                var alunos = new Aluno[] {
                    new Aluno{
                        AlunoNome = "Pelé",
                        Email = "lucas.muraro.pk@gmail.com",
                        DataInscricao = DateTime.Parse("2023-04-01"),
                    },
                };
                context.AddRange(alunos);
            }

            context.SaveChanges();
        }
    }
}