using DAOEscolhedorAlmoco.Modelos;
using NHibernate;
using NHibernate.Cfg;
using System.Configuration;
using FluentNHibernate.Cfg;

namespace DAOEscolhedorAlmoco.Infraestrutura
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var nhConfig = new NHibernate.Cfg.Configuration();
                    
                    var cn = ConfigurationManager.ConnectionStrings["cnEscolhedorAlmoco"];

                    nhConfig.SetProperty(Environment.ConnectionString, cn.ToString());

                    nhConfig.SetNamingStrategy(new QuotedNamingStrategy());
                    nhConfig.Configure();

                    _sessionFactory = Fluently.Configure(nhConfig)
                                              .Mappings(m => m.FluentMappings
                                                  .AddFromAssemblyOf<Restaurante>())
                                                  .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}