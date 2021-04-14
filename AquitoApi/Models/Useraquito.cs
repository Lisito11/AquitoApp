﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AquitoApi.Models
{
    public partial class Useraquito
    {
        public Useraquito()
        {
            Clients = new HashSet<Client>();
            Reservations = new HashSet<Reservation>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int Useraquitoid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Userpassword { get; set; }
        public string Userrole { get; set; }
        public string Phone { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
