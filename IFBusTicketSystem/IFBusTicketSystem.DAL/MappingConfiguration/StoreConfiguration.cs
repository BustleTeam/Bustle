using System;
using FluentNHibernate.Automapping;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.DAL.MappingConfiguration
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "IFBusTicketSystem.Foundation.Types";
        }

        public override bool IsComponent(Type type)
        {
            return type == typeof(Address) || type == typeof(Sex);
        }
    }
}
