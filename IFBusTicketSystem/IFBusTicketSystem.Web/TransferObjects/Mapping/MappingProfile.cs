using AutoMapper;
using IFBusTicketSystem.Foundation.Types.Entities;
using IFBusTicketSystem.Foundation.Types.ShortEntities;
using System.Collections.Generic;
using IFBusTicketSystem.Foundation.RequestEntities;
using IFBusTicketSystem.Foundation.Types;

namespace IFBusTicketSystem.Web.TransferObjects.Mapping
{
  public static class MappingProfile
  {
    public static IMapper Mapper => Config.CreateMapper();

    private static readonly MapperConfiguration Config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<Race, RaceDTO>()
              .ForMember(dto => dto.Route,
                  map => map.UseValue(new RouteDTO()))
              .ForMember(dto => dto.Arrival,
                  map => map.MapFrom(s => string.Format("{0:g}", s.Arrival)))
              .ForMember(dto => dto.Departure,
                  map => map.MapFrom(s => string.Format("{0:g}", s.Departure)))
              .ForMember(dto => dto.Stops,
                  map => map.UseValue(new List<StopDTO>()))
              .ForMember(dto => dto.Seats,
                  map => map.UseValue(new List<SeatDTO>()));

        cfg.CreateMap<RaceDTO, Race>()
                      .ForMember(dto => dto.Route,
                          map => map.UseValue(new Route()))
                      .ForMember(dto => dto.Stops,
                          map => map.UseValue(new List<Stop>()))
                      .ForMember(dto => dto.Seats,
                          map => map.UseValue(new List<Seat>()));

        cfg.CreateMap<ShortRace, ShortRaceDTO>().ReverseMap();

        cfg.CreateMap<Race, ShortRaceDTO>()
              .ForMember(dto => dto.RouteName,
                  map => map.MapFrom(r => r.Route.Name))
              .ForMember(dto => dto.RouteDescription,
                  map => map.MapFrom(r => r.Route.Description))
              .ForMember(dto => dto.Arrival,
                  map => map.MapFrom(s => string.Format("{0:g}", s.Arrival)))
              .ForMember(dto => dto.Departure,
                  map => map.MapFrom(s => string.Format("{0:g}", s.Departure)))
              .ForMember(dto => dto.Stops,
                  map => map.UseValue(new List<ShortStopDTO>()))
              .ForMember(dto => dto.Seats,
                  map => map.UseValue(new List<SeatDTO>()));

        cfg.CreateMap<Route, RouteDTO>()
                      .ForMember(dto => dto.Stations,
                          map => map.UseValue(new List<StationDTO>()));
        cfg.CreateMap<RouteDTO, Route>()
                      .ForMember(dto => dto.Stations,
                          map => map.UseValue(new List<Station>()));

        cfg.CreateMap<ShortRoute, ShortRouteDTO>().ReverseMap();

        cfg.CreateMap<Seat, SeatDTO>().ReverseMap();

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
                      .ForMember(dto => dto.Arrival,
                          map => map.MapFrom(s => string.Format("{0:g}", s.Arrival)))
                      .ForMember(dto => dto.Departure,
                          map => map.MapFrom(s => string.Format("{0:g}", s.Departure)))
                      .ForMember(dto => dto.Race,
                          map => map.UseValue(new RaceDTO()));

        cfg.CreateMap<StopDTO, Stop>()
                      .ForMember(dto => dto.Station,
                          map => map.UseValue(new Station()))
                      .ForMember(dto => dto.Race,
                          map => map.UseValue(new Race()));

        cfg.CreateMap<ShortStop, ShortStopDTO>().ReverseMap();

        cfg.CreateMap<Stop, ShortStopDTO>()
              .ForMember(dto => dto.StationName, map => map.MapFrom(s => s.Station.Name))
              .ForMember(dto => dto.Arrival,
                          map => map.MapFrom(s => string.Format("{0:g}", s.Arrival)))
              .ForMember(dto => dto.Departure,
                          map => map.MapFrom(s => string.Format("{0:g}", s.Departure)));

        cfg.CreateMap<Ticket, TicketDTO>()
                      .ForMember(dto => dto.Passenger,
                          map => map.UseValue(new UserDTO()))
                      .ForMember(dto => dto.Seat,
                          map => map.UseValue(new SeatDTO()));

        cfg.CreateMap<TicketDTO, Ticket>()
                      .ForMember(dto => dto.Passenger,
                          map => map.UseValue(new UserInfo()))
                      .ForMember(dto => dto.Seat,
                          map => map.UseValue(new Seat()));

        cfg.CreateMap<ShortTicket, ShortTicketDTO>().ReverseMap();

        cfg.CreateMap<UserDataWithOrders, UserDataDTO>();
              //.ForMember(dto => dto.Orders, map => map.UseValue(new TicketInfoDTO()));

        cfg.CreateMap<Ticket, TicketInfoDTO>()
              .ForMember(dto => dto.TicketId, map => map.MapFrom(t => t.Id))
              .ForMember(dto => dto.PassengerName,
                  map => map.MapFrom(t => $"{t.Passenger.LastName} {t.Passenger.FirstName}"))
              .ForMember(dto => dto.RaceName, map => map.MapFrom(t => t.Seat.Race.Route.Name))
              .ForMember(dto => dto.SeatNumber, map => map.MapFrom(t => t.Seat.Number));

        cfg.CreateMap<RegisterUserDTO, RegisterUserCommand>()
          .ForMember(_ => _.Login, map => map.MapFrom(t => t.UserName));

        //cfg.CreateMap<User, UserDTO>()
        //            .ForMember(dto => dto.AddressCountry,
        //                map => map.MapFrom(u => u.Address.Country))
        //            .ForMember(dto => dto.AddressCity,
        //                map => map.MapFrom(u => u.Address.City))
        //            .ForMember(dto => dto.AddressStreet,
        //                map => map.MapFrom(u => u.Address.Street))
        //            .ForMember(dto => dto.AddressBuilding,
        //                map => map.MapFrom(u => u.Address.Building));

        //cfg.CreateMap<UserDTO, User>()
        //            .ForMember(dto => dto.Address,
        //                map => map.MapFrom(u => new Address
        //                {
        //                    Country = u.AddressCountry,
        //                    City = u.AddressCity,
        //                    Street = u.AddressStreet,
        //                    Building = u.AddressBuilding
        //                }));
      });
  }
}