using AquitoApi.DTOs.TypeVehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.DTOs.Vehicle {
    public class VehicleReservacionDTO : VehicleCreacionDTO {
        public int Id { get; set; }
        public virtual TypeVehicleVehicleDTO Typevehicle { get; set; }
    }
}
