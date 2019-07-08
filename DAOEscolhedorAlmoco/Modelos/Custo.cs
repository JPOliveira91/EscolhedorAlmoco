using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DAOEscolhedorAlmoco.Modelos
{
    public class Custo
    {
        [DisplayName("IdCusto")]
        public virtual int IdCusto { get; set; }
        
        [DisplayName("DescricaoCusto")]
        public virtual string DescricaoCusto { get; set; }

        public virtual IList<Restaurante> Restaurante { get; set; }
    }
}