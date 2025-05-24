using Microsoft.AspNetCore.Mvc;
using API_Aluno_NetCore8.Entities;
using API_Aluno_NetCore8.Context;

namespace API_Aluno_NetCore8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunosContext _context;

        public AlunoController(AlunosContext context)
        {
            _context = context;
        }

        [HttpPost("CriarAluno")]
        public IActionResult Create(Aluno aluno)
        {
            var AlunoId = _context.Add(aluno);
            foreach (var disciplina in aluno.Disciplinas)
            {
                AlunoDisciplina alunoDisciplina = new AlunoDisciplina
                {
                    AlunoId = AlunoId.Entity.AlunoId,
                    DisciplinaId = disciplina.DisciplinaId
                };
                _context.Add(alunoDisciplina);
            }
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpGet("{Aluno_Id}")]
        public IActionResult ObterId(int Aluno_Id)
        {
            var alunoDisciplinas = _context.AlunoDisciplinas
                .Where(ad => ad.AlunoId == Aluno_Id)
                .ToList();

             var aluno = _context.Alunos.Find(Aluno_Id) ?? new Aluno();

            aluno.Disciplinas = _context.Disciplinas
                .Where(d => alunoDisciplinas.Any(ad => ad.DisciplinaId == d.DisciplinaId))
                .ToList();

            return Ok(aluno);
        }
    }
}
