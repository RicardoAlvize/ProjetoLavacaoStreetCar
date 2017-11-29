using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLavacaoStreetCar.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Marca { get; set; }

        [Required]
        [StringLength(255)]
        public string Modelo { get; set; }

        public string Cor { get; set; }

        [Required]
        [StringLength(255)]
        public string Placa { get; set; }


    }
}