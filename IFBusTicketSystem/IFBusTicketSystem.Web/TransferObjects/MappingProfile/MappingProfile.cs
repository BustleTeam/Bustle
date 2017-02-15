using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Race, RaceDetailsDTO>()
                .ForMember(dto => dto.RouteName,
                    map => map.MapFrom(r => r.Route.Name))
                .ForMember(dto => dto.RouteDescription,
                    map => map.MapFrom(r => r.Route.Description))
                .ForMember(dto => dto.Stops, 
                    map => map.UseValue(new List<StopDTO>()));

            CreateMap<Race, RaceDTO>()
                .ForMember(dto => dto.RouteName,
                    map => map.MapFrom(r => r.Route.Name))
                .ForMember(dto => dto.RouteDescription,
                    map => map.MapFrom(r => r.Route.Description));

            CreateMap<Route, RouteDetailsDTO>()
                .ForMember(dto => dto.Stations,
                    map => map.UseValue(new List<StationDTO>()));

            CreateMap<Route, RouteDTO>();

            CreateMap<Seat, SeatDTO>()
                .ForMember(dto => dto.RouteName,
                    map => map.MapFrom(s => s.Race.Route.Name));

            CreateMap<Station, StationDetailsDTO>()
                .ForMember(dto => dto.Routes,
                    map => map.UseValue(new List<RouteDTO>()));

            CreateMap<Station, StationDTO>();

            CreateMap<Stop, StopDTO>()
                .ForMember(dto => dto.Station,
                    map => map.MapFrom(s => s.Station.Name))
                .ForMember(dto => dto.Arrival,
                    map => map.MapFrom(s => string.Format("{0:g}", s.Arrival)))
                .ForMember(dto => dto.Departure,
                    map => map.MapFrom(s => string.Format("{0:g}", s.Departure)))
                .ForMember(dto => dto.RouteName,
                    map => map.MapFrom(s => s.Race.Route.Name));

            CreateMap<Ticket, TicketDTO>()
                .ForMember(dto => dto.PassengerName,
                    map => map.MapFrom(t => string.Format("{0} {1}",
                       t.Passenger.Name,
                       t.Passenger.Surname)))
                .ForMember(dto => dto.SeatNumber,
                    map => map.MapFrom(t => t.Seat.Number))
                .ForMember(dto => dto.RouteName,
                    map => map.MapFrom(t => t.Seat.Race.Route.Name));

            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.AddressCountry,
                    map => map.MapFrom(u => u.Address.Country))
                .ForMember(dto => dto.AddressCity,
                    map => map.MapFrom(u => u.Address.City))
                .ForMember(dto => dto.AddressStreet,
                    map => map.MapFrom(u => u.Address.Street))
                .ForMember(dto => dto.AddressBuilding,
                    map => map.MapFrom(u => u.Address.Building));

            CreateMap<Sex, string>().ConvertUsing(src => src.ToString());
        }
    }
}