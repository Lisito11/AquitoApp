using AquitoApi.DTOs.Client;
using AquitoApi.DTOs.Reservation;
using AquitoApi.DTOs.TypeVehicle;
using AquitoApi.DTOs.Vehicle;
using AquitoApi.Entities;
using AquitoApi.Entities.Request;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.Helpers {
    public class AutoMapperProfiles: Profile {
        public AutoMapperProfiles() {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<ClientCreacionDTO, Client>();

            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<VehicleCreacionDTO, Vehicle>();

            CreateMap<Typevehicle, TypevehicleDTO>().ReverseMap();
            CreateMap<TypevehicleCreacionDTO, Typevehicle>();

            CreateMap<Reservation, ReservationDTO>().ReverseMap();
            CreateMap<ReservationCreacionDTO, Reservation>();

            CreateMap<Useraquito, UserRequest>().ReverseMap();
        }
    }
}
