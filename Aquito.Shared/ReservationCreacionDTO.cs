using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aquito.Shared {
    public class ReservationCreacionDTO {
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public decimal? Totalpay { get; set; }
        public int? Vehicleid { get; set; }
        public int? Clientid { get; set; }
        public int? Useraquitoid { get; set; }
        public int? Status { get; set; }
    }
}
