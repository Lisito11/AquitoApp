using AquitoApi.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace AquitoApi.Entities {
    public partial class Reservation : IId {
        public int Id { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public decimal? Totalpay { get; set; }
        public int? Vehicleid { get; set; }
        public int? Clientid { get; set; }
        public int? Useraquitoid { get; set; }
        public int? Status { get; set; }

        public virtual Client Client { get; set; }
        public virtual Useraquito Useraquito { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
