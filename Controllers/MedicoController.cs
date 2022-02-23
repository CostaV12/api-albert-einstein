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
    public class MedicoController : Controller
    {
        private AlbertEinsteinContext _context;

        public MedicoController(AlbertEinsteinContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Read), new { Id = medico.IdMedico}, medico);
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_context.Medicos);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            Medico medico = _context.Medicos.FirstOrDefault(medico => medico.IdMedico == id);
            if (medico != null)
            {
                return Ok(medico);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Medico medicoAtualizado)
        {
            Medico medico = _context.Medicos.FirstOrDefault(medico => medico.IdMedico == id);
            if (medico == null)
                return NotFound();
            medico.Nome = medicoAtualizado.Nome;
            medico.Especialidade = medicoAtualizado.Especialidade;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Medico medico = _context.Medicos.FirstOrDefault(medico => medico.IdMedico == id);
            if (medico == null)
                return NotFound();
            _context.Remove(medico);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
