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
    public class NHibernateCustoRepository
    {
        private readonly ISession _session;

        public NHibernateCustoRepository()
        {
            _session = NHibernateHelper.OpenSession();
        }

        public NHibernateCustoRepository(ISession session = null)
        {
            _session = session ?? NHibernateHelper.OpenSession();
        }

        public void SaveOrUpdate(Custo Custo)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(Custo);

                transaction.Commit();
            }
        }

        public IQueryable<Custo> ObterTodos()
        {
            return _session.Query<Custo>();
        }
    }
}