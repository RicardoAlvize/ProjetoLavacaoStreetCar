using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLavacaoStreetCar.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        [Required]
        [StringLength(255)]
        public string Cpf { get; set; }

        public string Endereco { get; set; }

        [Required]
        [StringLength(255)]
        public string Telefone { get; set; }

        public Carro Carro { get; set; }

        public int CarroId { get; set; }

    }
}