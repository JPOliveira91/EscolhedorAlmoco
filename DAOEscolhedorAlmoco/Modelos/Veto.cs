using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DAOEscolhedorAlmoco.Modelos
{
    public class Veto
    {
        [DisplayName("IdVeto")]
        public virtual int IdVeto { get; set; }

        [DisplayName("DescricaoVeto")]
        public virtual string DescricaoVeto { get; set; }

        public virtual IList<Restaurante> Restaurante { get; set; }
    }
}