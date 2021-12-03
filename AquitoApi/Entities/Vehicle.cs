using System;
using System.Collections.Generic;

#nullable disable

namespace AquitoApi.Entities {
    public partial class Vehicle: IId
    {
        public Vehicle()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Age { get; set; }
        public decimal? Priceday { get; set; }
        public decimal? Price { get; set; }
        public decimal? Weightcapacity { get; set; }
        public int? Passengers { get; set; }
        public string Matricula { get; set; }
        public string Securitynum { get; set; }
        public string Vehiclepic { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? Typevehicleid { get; set; }
        public int? Useraquitoid { get; set; }
        public string Color { get; set; }
        public int? Status { get; set; }

        public virtual Typevehicle Typevehicle { get; set; }
        public virtual Useraquito Useraquito { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
