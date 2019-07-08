using DAOEscolhedorAlmoco.Modelos;
using FluentNHibernate.Mapping;

namespace DAOEscolhedorAlmoco.Mapeamentos
{
    public class CustoMap : ClassMap<Custo>
    {
        public CustoMap()
        {
            Id(r => r.IdCusto).GeneratedBy.Increment();
            Map(r => r.DescricaoCusto);

            HasManyToMany(r => r.Restaurante).Table("Restaurante_Custo").ParentKeyColumn("IdRestaurante").ChildKeyColumn("IdCusto").Inverse();
        }
    }
}