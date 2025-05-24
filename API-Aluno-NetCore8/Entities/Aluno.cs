using System.Collections.Generic;

namespace API_Aluno_NetCore8.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? RA { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();


    }
}
