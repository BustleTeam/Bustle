using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public static class UserConverter
    {
        public static UserDTO ToDto(this User user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>()
                        .ForMember(dto => dto.AddressCountry,
                            map => map.MapFrom(u => u.Address.Country))
                        .ForMember(dto => dto.AddressCity,
                            map => map.MapFrom(u => u.Address.City))
                        .ForMember(dto => dto.AddressStreet,
                            map => map.MapFrom(u => u.Address.Street))
                        .ForMember(dto => dto.AddressBuilding,
                            map => map.MapFrom(u => u.Address.Building));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<User, UserDTO>(user);
        }

        public static User FromDto(this UserDTO userDto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>()
                        .ForMember(dto => dto.Address,
                            map => map.MapFrom(u => new Address
                            {
                                Country = u.AddressCountry,
                                City = u.AddressCity,
                                Street = u.AddressStreet,
                                Building = u.AddressBuilding
                            }));
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<UserDTO, User>(userDto);
        }
    }
}