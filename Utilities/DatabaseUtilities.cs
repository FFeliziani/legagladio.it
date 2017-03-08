using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LegaGladio.Entities.Mappings;
using NHibernate;

namespace Utilities
{
    public static class DatabaseUtilities
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory CreateSessionFactory()
        {
            _sessionFactory = Fluently
                .Configure()
                .Database(
                    MySQLConfiguration.Standard.ConnectionString(
                        c =>
                            c.Database(Constants.DbName)
                                .Username(Constants.DbUser)
                                .Server(Constants.DbHost)
                                .Password(Constants.DbPassword)))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<PlayerMap>())
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .BuildSessionFactory();
            return _sessionFactory;
        }
    }
}
