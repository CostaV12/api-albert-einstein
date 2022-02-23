using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlbertEinstein.Models
{
    public class Consulta
    {
        [Key]
        [Required]
        public int IdConsulta { get; set; }
        [Required]
        public DateTime DataConsulta { get; set; }
        [Required]
        public int IdMedico { get; set; }
        [Required]
        public int IdPaciente { get; set; }
    }
}
