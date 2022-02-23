using ApiAlbertEinstein.Data;
using ApiAlbertEinstein.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiAlbertEinstein.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : Controller
    {
        private AlbertEinsteinContext _context;

        public PacienteController(AlbertEinsteinContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Read), new { Id = paciente.IdPaciente }, paciente);
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_context.Pacientes);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            Paciente paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.IdPaciente == id);
            if (paciente != null)
            {
                return Ok(paciente);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Paciente pacienteAtualizado)
        {
            Paciente paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.IdPaciente == id);
            if (paciente == null)
                return NotFound();
            paciente.Nome = pacienteAtualizado.Nome;
            paciente.Idade = pacienteAtualizado.Idade;
            paciente.Sexo = pacienteAtualizado.Sexo;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Paciente paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.IdPaciente == id);
            if (paciente == null)
                return NotFound();
            _context.Remove(paciente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
