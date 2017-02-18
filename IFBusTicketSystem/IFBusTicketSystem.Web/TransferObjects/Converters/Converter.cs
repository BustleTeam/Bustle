using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class Converter
    {
        public static DTO ToDto<Type, DTO>(this Type obj)
            where DTO : IEntityDTO 
            where Type : IEntity
        {
            return MappingProfile.Mapper.Map<Type, DTO>(obj);
        }        

        public static IEnumerable<DTO> ToDto<Type, DTO>(this IEnumerable<Type> obj)
            where DTO : IEntityDTO
            where Type : IEntity
        {
            return MappingProfile.Mapper.Map<IEnumerable<Type>, IEnumerable<DTO>>(obj);
        }

        public static Type FromDto<DTO, Type>(this DTO obj)
            where DTO : IEntityDTO
            where Type : IEntity
        {
            return MappingProfile.Mapper.Map<DTO, Type>(obj);
        }

        public static IEnumerable<Type> FromDto<DTO, Type>(this IEnumerable<DTO> obj)
            where DTO : IEntityDTO
            where Type : IEntity
        {
            return MappingProfile.Mapper.Map<IEnumerable<DTO>, IEnumerable<Type>>(obj);
        }
    }
}