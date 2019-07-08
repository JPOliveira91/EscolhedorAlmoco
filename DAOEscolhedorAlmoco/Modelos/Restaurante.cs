using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DAOEscolhedorAlmoco.Modelos
{
    public class Restaurante
    {
        [DisplayName("IdRestaurante")]
        public virtual int IdRestaurante { get; set; }

        [DisplayName("Nome")]
        public virtual string Nome { get; set; }

        [DisplayName("Apelido")]
        public virtual string Apelido { get; set; }

        [DisplayName("Endereco")]
        public virtual string Endereco { get; set; }

        [DisplayName("Observacao")]
        public virtual string Observacao { get; set; }

        public virtual IList<Custo> Custos { get; set; }

        public virtual IList<Tipo> Tipos { get; set; }

        public virtual IList<Veto> Vetos { get; set; }
    }
}
