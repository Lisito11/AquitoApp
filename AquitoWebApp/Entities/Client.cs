using AquitoWebApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace AquitoWebApp.Entities {
    public partial class Client : IId
    {
        public Client()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Licence { get; set; }
        public string Nacionality { get; set; }
        public string Typeblood { get; set; }
        public string Userpic { get; set; }
        public string Licencepic { get; set; }
        public int? Useraquitoid { get; set; }

        public int? Status { get; set; }

        [DisplayName("Usuarios")]
        public virtual Useraquito Useraquito { get; set; }
        [DisplayName("Reservaciones")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
