using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aquito.Shared {
    public class TypevehicleDTO: TypevehicleCreacionDTO {
        public int Id { get; set; }
        public virtual ICollection<VehicleDTO> Vehicles { get; set; }
    }
}
