using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DAOEscolhedorAlmoco.Modelos;

namespace EscolhedorAlmoco.Models
{
    public class RestauranteFiltro
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        [DisplayName("Endereco")]
        public string Endereco { get; set; }
        
        [DisplayName("Observacao")]
        public string Observacao { get; set; }

        public IList<Custo> Custos { get; set; }

        public IList<Tipo> Tipos { get; set; }

        public IList<Veto> Vetos { get; set; }

        public List<Restaurante> Restaurantes { get; set; }
        
        public List<int> VetosSelecionados { get; set; }
        public List<SelectListItem> VetosDisponiveis { get; set; }

        public List<int> TiposSelecionados { get; set; }
        public List<SelectListItem> TiposDisponiveis { get; set; }

        public List<int> CustosSelecionados { get; set; }
        public List<SelectListItem> CustosDisponiveis { get; set; }

        public RestauranteFiltro()
        {
            VetosSelecionados = new List<int>();
            VetosDisponiveis = new List<SelectListItem>();
            TiposSelecionados = new List<int>();
            TiposDisponiveis = new List<SelectListItem>();
            CustosSelecionados = new List<int>();
            CustosDisponiveis = new List<SelectListItem>();
        }
    }
}