using Aula005.RazorPages.Model;
using Microsoft.EntityFrameworkCore;

namespace Aula005.RazorPages.Data {
        public class AppDbContext : DbContext
    {
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Aluno>? Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Curso>().ToTable("Eventos").HasKey(e => e.CursoId);
            modelBuilder.Entity<Curso>().Property(e=>e.CursoId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Aluno>().ToTable("Jogadores").HasKey(j => j.AlunoId);
            modelBuilder.Entity<Aluno>().Property(p=>p.AlunoId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Aluno)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "CursoAluno",
                    j => j.HasOne<Aluno>().WithMany().HasForeignKey("AlunoId"),
                    e => e.HasOne<Curso>().WithMany().HasForeignKey("CursoId"),
                    eJ =>
                    {
                        eJ.HasKey("CursoId", "AlunoId");
                        eJ.ToTable("CursosEAlunos");
                    });
        }
    }

}