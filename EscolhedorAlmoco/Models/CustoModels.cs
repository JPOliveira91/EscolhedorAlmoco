using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DAOEscolhedorAlmoco.Modelos;

namespace EscolhedorAlmoco.Models
{

    public class CustoFiltro
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Descrição")]
        public string DescricaoCusto { get; set; }
    }
}