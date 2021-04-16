using AquitoApi.DTOs.Client;
using AquitoApi.DTOs.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.DTOs.Reservation {
    public class ReservationDTO: ReservationCreacionDTO {
        public int Id { get; set; }
        public virtual ClientDTO Client { get; set; }
        public virtual VehicleDTO Vehicle { get; set; }

        

    }
}
