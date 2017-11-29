using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLavacaoStreetCar.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Matricula { get; set; }

        public string Horario { get; set; }

    }
}