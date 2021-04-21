using AquitoApi.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace AquitoApi.Entities
{
    public partial class Useraquito : IdentityUser<int>
    {
        public Useraquito()
        {
            Clients = new HashSet<Client>();
            Reservations = new HashSet<Reservation>();
            Vehicles = new HashSet<Vehicle>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
