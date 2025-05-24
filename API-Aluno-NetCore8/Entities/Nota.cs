namespace API_Aluno_NetCore8.Entities
{
    public class Nota
    {
        public int NotaId { get; set; }
        public decimal Valor { get; set; }

        public int AlunoId { get; set; }

        public int DisciplinaId { get; set; }
    }
}
