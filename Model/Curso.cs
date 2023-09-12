namespace Aula005.RazorPages.Model
{
    public class Curso
    {   public int? CursoId { get; set; }
        public string? NomeCurso{ get; set; }
        public string? Descricao { get; set; }   
        public DateTime? DateInicio {get;set;}
        public DateTime? DateTermino {get;set;}
        public List<Aluno>? Aluno {get; set;}

    }
}