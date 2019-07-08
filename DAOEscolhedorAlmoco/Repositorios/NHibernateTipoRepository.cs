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
    public class NHibernateTipoRepository
    {
        private readonly ISession _session;

        public NHibernateTipoRepository()
        {
            _session = NHibernateHelper.OpenSession();
        }

        public NHibernateTipoRepository(ISession session = null)
        {
            _session = session ?? NHibernateHelper.OpenSession();
        }

        public void SaveOrUpdate(Tipo Tipo)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(Tipo);

                transaction.Commit();
            }
        }

        public IQueryable<Tipo> ObterTodos()
        {
            return _session.Query<Tipo>();
        }
    }
}