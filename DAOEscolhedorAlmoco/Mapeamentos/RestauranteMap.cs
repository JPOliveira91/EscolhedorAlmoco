using DAOEscolhedorAlmoco.Modelos;
using FluentNHibernate.Mapping;

namespace DAOEscolhedorAlmoco.Mapeamentos
{
    public class RestauranteMap : ClassMap<Restaurante>
    {
        public RestauranteMap()
        {
            Id(r => r.IdRestaurante).GeneratedBy.Increment();
            Map(r => r.Nome);
            Map(r => r.Apelido);
            Map(r => r.Endereco);
            Map(r => r.Observacao);

            HasManyToMany(r => r.Custos).Table("Restaurante_Custo").ParentKeyColumn("IdRestaurante").ChildKeyColumn("IdCusto");
            HasManyToMany(r => r.Tipos).Table("Restaurante_Tipo").ParentKeyColumn("IdRestaurante").ChildKeyColumn("IdTipo");
            HasManyToMany(r => r.Vetos).Table("Restaurante_Veto").ParentKeyColumn("IdRestaurante").ChildKeyColumn("IdVeto");
        }
    }
}