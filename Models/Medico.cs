using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAlbertEinstein.Models
{
    public class Medico
    {
        [Key]
        [Required]
        public int IdMedico { get; set; }
        [Required(ErrorMessage = "O nome do médico é obrigatório")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Insira um nome válido")]
        public string Nome { get; set; }
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Insira uma especialidade válida")]
        public string Especialidade { get; set; }
    }
}
