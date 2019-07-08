using DAOEscolhedorAlmoco.Modelos;
using FluentNHibernate.Mapping;

namespace DAOEscolhedorAlmoco.Mapeamentos
{
    public class TipoMap : ClassMap<Tipo>
    {
        public TipoMap()
        {
            Id(r => r.IdTipo).GeneratedBy.Increment();
            Map(r => r.DescricaoTipo);

            HasManyToMany(r => r.Restaurante).Table("Restaurante_Tipo").ParentKeyColumn("IdRestaurante").ChildKeyColumn("IdTipo").Inverse();
        }
    }
}