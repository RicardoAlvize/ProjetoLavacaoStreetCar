using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLavacaoStreetCar.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Cpf { get; set; }

        public string Endereco { get; set; }

        public int Telefone { get; set; }

        public Carro Carro { get; set; }

        public int CarroId { get; set; }

    }
}