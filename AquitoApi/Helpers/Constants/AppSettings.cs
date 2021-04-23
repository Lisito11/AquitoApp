using AquitoApi.DTOs.Client;
using AquitoApi.DTOs.Reservation;
using AquitoApi.DTOs.TypeVehicle;
using AquitoApi.DTOs.Vehicle;
using AquitoApi.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.Helpers.Constants
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Authority { get; set; }
        public string Issuer { get; set; }
    }
}
