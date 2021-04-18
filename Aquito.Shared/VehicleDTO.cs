using Aquito.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aquito.Shared {
    public class VehicleDTO: VehicleCreacionDTO {
        public int Id { get; set; }
        public virtual TypevehicleDTO Typevehicle { get; set; }
        public virtual ICollection<ReservationDTO> Reservations { get; set; }
    }
}
