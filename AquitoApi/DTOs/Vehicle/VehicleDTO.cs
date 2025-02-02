﻿using AquitoApi.DTOs.Reservation;
using AquitoApi.DTOs.TypeVehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.DTOs.Vehicle {
    public class VehicleDTO: VehicleCreacionDTO {
        public int Id { get; set; }
        public virtual TypeVehicleVehicleDTO Typevehicle { get; set; }
        public virtual ICollection<ReservationDTO> Reservations { get; set; }
    }
}
