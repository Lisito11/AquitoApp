using AquitoApi.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace AquitoApi.Entities {
    public partial class Typevehicle : IId 
        {
        public Typevehicle()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Namevehicle { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
