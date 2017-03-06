using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps;
using IFBusTicketSystem.DAL.MappingConfiguration.EntityMaps5454;
using IFBusTicketSystem.Foundation.Constants;
using IFBusTicketSystem.Foundation.Types.Entities;
using NHibernate;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Tool.hbm2ddl;
using NLog;

namespace IFBusTicketSystem.DAL.MappingConfiguration
{
    public static class FluentNhibernateConfiguration
    {
        public static ISessionFactory GetSessionFactory
        {
            get
            {
                try
                {
                    return Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2012.ConnectionString(
                                ConfigurationManager.ConnectionStrings["BustleDB"].ConnectionString))
                        //.Mappings(_ => _.AutoMappings.Add(AutoMap.AssemblyOf<Race>(new StoreConfiguration())))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StationMap>())
                        .ExposeConfiguration(_ =>
                        {
                            _.AddDeserializedMapping(
                                MappingHelper.GetIdentityMappings(new[] { typeof(UserInfo) }),
                                null);
                            //new SchemaExport(_).Create(true,true);
                            new SchemaUpdate(_).Execute(false, true);
                        })
                        .BuildSessionFactory();
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger(LogHelper.LoggerName);
                    logger.Error(e);
                    return null;
                }
            } 
        }
    }
}
