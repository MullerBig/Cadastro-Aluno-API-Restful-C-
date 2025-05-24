using API_Aluno_NetCore8.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Aluno_NetCore8.Context
{
    public class AlunosContext : DbContext
    {
        public AlunosContext(DbContextOptions<AlunosContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }

    }
}
