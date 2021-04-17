using AquitoApi.DTOs.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aquito.Share.Client {
    public class ClientDTO/*: ClientCreacionDTO*/ {
        public int Id { get; set; }
        public virtual ICollection<ReservationDTO> Reservations { get; set; }
    }
}
