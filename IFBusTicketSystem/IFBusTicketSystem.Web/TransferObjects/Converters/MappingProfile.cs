﻿using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using System.Collections.Generic;

namespace IFBusTicketSystem.Web.TransferObjects.Converters
{
    public class MappingProfile
    {
        public static IMapper Mapper = Config.CreateMapper();

        public static MapperConfiguration Config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Race, RaceDTO>()
                    .ForMember(dto => dto.Route,
                        map => map.UseValue(new RouteDTO()))
                    .ForMember(dto => dto.Stops,
                        map => map.UseValue(new List<StopDTO>()));

            cfg.CreateMap<RaceDTO, Race>()
                        .ForMember(dto => dto.Route,
                            map => map.UseValue(new Route()))
                        .ForMember(dto => dto.Stops,
                            map => map.UseValue(new List<Stop>()));

            cfg.CreateMap<ShortRace, ShortRaceDTO>().ReverseMap();

            cfg.CreateMap<Route, RouteDTO>()
                        .ForMember(dto => dto.Stations,
                            map => map.UseValue(new List<StationDTO>()));
            cfg.CreateMap<RouteDTO, Route>()
                        .ForMember(dto => dto.Stations,
                            map => map.UseValue(new List<Station>()));

            cfg.CreateMap<ShortRoute, ShortRouteDTO>().ReverseMap();

            cfg.CreateMap<Seat, SeatDTO>()
                        .ForMember(dto => dto.Race,
                            map => map.UseValue(new RaceDTO()));

            cfg.CreateMap<SeatDTO, Seat>()
                        .ForMember(dto => dto.Race,
                            map => map.UseValue(new Race()));

            cfg.CreateMap<ShortSeat, ShortSeatDTO>().ReverseMap();

            cfg.CreateMap<Station, StationDTO>()
                        .ForMember(dto => dto.Routes,
                            map => map.UseValue(new List<RouteDTO>()));

            cfg.CreateMap<StationDTO, Station>()
                        .ForMember(dto => dto.Routes,
                            map => map.UseValue(new List<Route>()));

            cfg.CreateMap<ShortStation, ShortStationDTO>().ReverseMap();

            cfg.CreateMap<Stop, StopDTO>()
                        .ForMember(dto => dto.Station,
                            map => map.UseValue(new StationDTO()))
                        .ForMember(dto => dto.Race,
                            map => map.UseValue(new RaceDTO()));

            cfg.CreateMap<StopDTO, Stop>()
                        .ForMember(dto => dto.Station,
                            map => map.UseValue(new Station()))
                        .ForMember(dto => dto.Race,
                            map => map.UseValue(new Race()));

            cfg.CreateMap<ShortStop, ShortStopDTO>().ReverseMap();

            cfg.CreateMap<Ticket, TicketDTO>()
                        .ForMember(dto => dto.Passenger,
                            map => map.UseValue(new UserDTO()))
                        .ForMember(dto => dto.Seat,
                            map => map.UseValue(new SeatDTO()));

            cfg.CreateMap<TicketDTO, Ticket>()
                        .ForMember(dto => dto.Passenger,
                            map => map.UseValue(new User()))
                        .ForMember(dto => dto.Seat,
                            map => map.UseValue(new Seat()));

            cfg.CreateMap<ShortTicket, ShortTicketDTO>().ReverseMap();

            cfg.CreateMap<User, UserDTO>()
                        .ForMember(dto => dto.AddressCountry,
                            map => map.MapFrom(u => u.Address.Country))
                        .ForMember(dto => dto.AddressCity,
                            map => map.MapFrom(u => u.Address.City))
                        .ForMember(dto => dto.AddressStreet,
                            map => map.MapFrom(u => u.Address.Street))
                        .ForMember(dto => dto.AddressBuilding,
                            map => map.MapFrom(u => u.Address.Building));

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
    }
}