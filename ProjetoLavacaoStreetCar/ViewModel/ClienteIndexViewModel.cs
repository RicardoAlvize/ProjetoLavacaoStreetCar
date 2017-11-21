using ProjetoLavacaoStreetCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLavacaoStreetCar.ViewModel
{
    public class ClienteIndexViewModel
    {
        public List<Carro> Carros  { get; set; }
        public Cliente Cliente { get; set; }
        public string Title
        {
            get
            {
                if (Cliente != null && Cliente.Id != 0)
                    return "Editar Cliente";

                return "Novo Cliente";
            }
        }
    }
}