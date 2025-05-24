using Microsoft.AspNetCore.Mvc;
using API_Aluno_NetCore8.Entities;
using API_Aluno_NetCore8.Context;

namespace API_Aluno_NetCore8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly AlunosContext _context;

        public DisciplinaController(AlunosContext context)
        {
            _context = context;
        }

        [HttpPost("CriarDisciplina")]
        public IActionResult Create(Disciplina disciplina)
        {
            _context.Add(disciplina);
            _context.SaveChanges();
            return Ok(disciplina);
        }

        [HttpGet("{Disciplina_Id}")]
        public IActionResult ObterId(int Disciplina_Id)
        {
            var disciplina = _context.Disciplinas.Find(Disciplina_Id);

            if (disciplina == null)
            {
                return NotFound();
            }
            return Ok(disciplina);
        }
    }
}
