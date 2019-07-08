using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DAOEscolhedorAlmoco.Modelos
{
    public class Tipo
    {
        [DisplayName("IdTipo")]
        public virtual int IdTipo { get; set; }

        [DisplayName("DescricaoTipo")]
        public virtual string DescricaoTipo { get; set; }

        public virtual IList<Restaurante> Restaurante { get; set; }
    }
}