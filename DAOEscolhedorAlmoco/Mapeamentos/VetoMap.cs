using DAOEscolhedorAlmoco.Modelos;
using FluentNHibernate.Mapping;

namespace DAOEscolhedorAlmoco.Mapeamentos
{
    public class VetoMap : ClassMap<Veto>
    {
        public VetoMap()
        {
            Id(r => r.IdVeto).GeneratedBy.Increment();
            Map(r => r.DescricaoVeto);

            HasManyToMany(r => r.Restaurante).Table("Restaurante_Veto").ParentKeyColumn("IdRestaurante").ChildKeyColumn("IdVeto").Inverse();
        }
    }
}