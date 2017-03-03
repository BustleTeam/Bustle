using System.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IFBusTicketSystem.Foundation.Types.Entities;
using NHibernate;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Tool.hbm2ddl;

namespace IFBusTicketSystem.DAL.MappingConfiguration
{
    public static class FluentNhibernateConfiguration
    {
        public static ISessionFactory GetSessionFactory { get; } = Fluently.Configure()
            .Database(
                MsSqlConfiguration.MsSql2012.ConnectionString(
                    ConfigurationManager.ConnectionStrings["BustleDB"].ConnectionString))
            .Mappings(_ => _.AutoMappings.Add(AutoMap.AssemblyOf<Race>(new StoreConfiguration())))
            .ExposeConfiguration(_ =>
            {
               // _.AddDeserializedMapping(MappingHelper.GetIdentityMappings(new[]{typeof(User)}), null);
                new SchemaUpdate(_).Execute(false, true);
            })
            .BuildSessionFactory();
    }
}
