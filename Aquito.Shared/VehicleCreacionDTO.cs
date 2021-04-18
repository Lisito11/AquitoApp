using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aquito.Shared {
    public class VehicleCreacionDTO {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Age { get; set; }
        public decimal? Priceday { get; set; }
        public decimal? Weightcapacity { get; set; }
        public int? Passengers { get; set; }
        public string Matricula { get; set; }
        public string Securitynum { get; set; }
        public string Vehiclepic { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? Typevehicleid { get; set; }
        public int? Useraquitoid { get; set; }
        public int? Status { get; set; }
    }
}
