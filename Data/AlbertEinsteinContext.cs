using ApiAlbertEinstein.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlbertEinstein.Data
{
    public class AlbertEinsteinContext : DbContext
    {
        public AlbertEinsteinContext(DbContextOptions<AlbertEinsteinContext> opt) : base(opt)
        {

        }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}
