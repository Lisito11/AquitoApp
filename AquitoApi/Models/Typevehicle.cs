using System;
using System.Collections.Generic;

#nullable disable

namespace AquitoApi.Models
{
    public partial class Typevehicle
    {
        public Typevehicle()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Typevehicleid { get; set; }
        public string Namevehicle { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
