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
    public class NHibernateVetoRepository
    {
        private readonly ISession _session;

        public NHibernateVetoRepository()
        {
            _session = NHibernateHelper.OpenSession();
        }

        public NHibernateVetoRepository(ISession session = null)
        {
            _session = session ?? NHibernateHelper.OpenSession();
        }

        public void SaveOrUpdate(Veto Veto)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(Veto);

                transaction.Commit();
            }
        }

        public IQueryable<Veto> ObterTodos()
        {
            return _session.Query<Veto>();
        }
    }
}