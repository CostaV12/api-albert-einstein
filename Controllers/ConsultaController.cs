using ApiAlbertEinstein.Data;
using ApiAlbertEinstein.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlbertEinstein.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaController : Controller
    {
        private AlbertEinsteinContext _context;

        public ConsultaController(AlbertEinsteinContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Consulta consulta)
        {
            Medico medico = _context.Medicos.FirstOrDefault(medico => (medico.IdMedico == consulta.IdMedico));
            Paciente paciente = _context.Pacientes.FirstOrDefault(paciente => (paciente.IdPaciente == paciente.IdPaciente));
            Consulta consultasMarcadas = _context.Consultas.FirstOrDefault(consultasMarcadas => (consultasMarcadas.DataConsulta == consulta.DataConsulta) && (consultasMarcadas.IdMedico == consulta.IdMedico));
            
            if(consultasMarcadas == null && medico != null && paciente != null)
            {
                _context.Consultas.Add(consulta);
                _context.SaveChanges();
                return CreatedAtAction(nameof(ReadConsultaPaciente), new { Id = consulta.IdPaciente }, consulta);
            }
            
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_context.Consultas);
        }

        [HttpGet("consulta/{id}")]
        public IActionResult ReadConsulta(int id)
        {
            Consulta consulta = _context.Consultas.FirstOrDefault(consulta => consulta.IdConsulta == id);
            if (consulta != null)
            {
                return Ok(consulta);
            }
            return NotFound();
        }

        [HttpGet("consultas-medico/{id}")]
        public IActionResult ReadConsultaMedico(int id)
        {
            Consulta consulta = _context.Consultas.FirstOrDefault(consulta => consulta.IdMedico == id);
            if (consulta != null)
            {
                return Ok(consulta);
            }
            return NotFound();
        }
        [HttpGet("consultas-paciente/{id}")]
        public IActionResult ReadConsultaPaciente(int id)
        {
            Consulta consulta = _context.Consultas.FirstOrDefault(consulta => consulta.IdPaciente == id);
            if (consulta != null)
            {
                return Ok(consulta);
            }
            return NotFound();
        }
    }
}
