using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.DTOs.Client {
    public class ClientCreacionDTO {
        public string Cedula { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Licence { get; set; }
        public string Nacionality { get; set; }
        public string Typeblood { get; set; }
        public string Userpic { get; set; }
        public string Licencepic { get; set; }
        public int? Status { get; set; }
    }
}
