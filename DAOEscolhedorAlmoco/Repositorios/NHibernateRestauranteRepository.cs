using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOEscolhedorAlmoco.Modelos;
using NHibernate;
using DAOEscolhedorAlmoco.Infraestrutura;
using NHibernate.Linq;

namespace DAOEscolhedorAlmoco.Repositorios
{
    public class NHibernateRestauranteRepository
    {
        private readonly ISession _session;

        public NHibernateRestauranteRepository()
        {
            _session = NHibernateHelper.OpenSession();
        }

        public NHibernateRestauranteRepository(ISession session = null)
        {
            _session = session ?? NHibernateHelper.OpenSession();
        }

        public void SaveOrUpdate(Restaurante restaurante)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(restaurante);

                transaction.Commit();
            }
        }

        public IQueryable<Restaurante> ObterTodos()
        {
            return _session.Query<Restaurante>();
        }
    }
}