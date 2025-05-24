using Microsoft.AspNetCore.Mvc;
using API_Aluno_NetCore8.Entities;
using API_Aluno_NetCore8.Context;

namespace API_Aluno_NetCore8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly AlunosContext _context;

        public NotaController(AlunosContext context)
        {
            _context = context;
        }

        [HttpPost("CriarNota")]
        public IActionResult Create(Nota nota)
        {
            _context.Add(nota);
            _context.SaveChanges();
            return Ok(nota);
        }

        [HttpGet("{Nota_Id}")]
        public IActionResult ObterId(int Nota_Id)
        {
            var nota = _context.Notas.Find(Nota_Id);

            if (nota == null)
            {
                return NotFound();
            }
            return Ok(nota);
        }
    }
}
