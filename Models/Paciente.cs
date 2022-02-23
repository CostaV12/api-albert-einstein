using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlbertEinstein.Models
{
    public class Paciente
    {
        [Key]
        [Required]
        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "O nome do médico é obrigatório")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Insira um nome válido")]
        public string Nome { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        [Range(0, 120)]
        public int Idade { get; set; }
    }
}
