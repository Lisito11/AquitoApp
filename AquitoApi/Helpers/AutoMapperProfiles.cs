using AquitoApi.DTOs.Client;
using AquitoApi.DTOs.Facturas606;
using AquitoApi.DTOs.Facturas607;
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

            CreateMap<Factura606, Factura606DTO>().ReverseMap();
            CreateMap<Factura606CreacionDTO, Factura606>();

            CreateMap<FacturaDetalle606, FacturaDetalle606DTO>().ReverseMap();
            CreateMap<FacturaDetalle606CreacionDTO, FacturaDetalle606>();

            CreateMap<Factura607, Factura607DTO>().ReverseMap();
            CreateMap<Factura607CreacionDTO, Factura607>();

            CreateMap<FacturaDetalle607, FacturaDetalle607DTO>().ReverseMap();
            CreateMap<FacturaDetalle607CreacionDTO, FacturaDetalle607>();

            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleReservacionDTO>().ReverseMap();
            CreateMap<VehicleCreacionDTO, Vehicle>();

            CreateMap<Typevehicle, TypevehicleDTO>().ReverseMap();
            CreateMap<Typevehicle, TypeVehicleVehicleDTO>().ReverseMap();
            CreateMap<TypevehicleCreacionDTO, Typevehicle>();

            CreateMap<Reservation, ReservationDTO>().ReverseMap();
            CreateMap<ReservationCreacionDTO, Reservation>();

            CreateMap<Useraquito, UserRequest>().ReverseMap();
        }
    }
}
