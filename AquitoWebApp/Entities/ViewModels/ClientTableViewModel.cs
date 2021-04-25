using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoWebApp.Entities.ViewModels
{
    public class ClienTableViewModel
    {
        public int Id { get; set; }
        [DisplayName("Cedula")]
        public string Cedula { get; set; }
        [DisplayName("Nombre")]
        public string Firstname { get; set; }
        [DisplayName("Apellido")]
        public string Lastname { get; set; }

        [DisplayName("Monto que debe")]
        public Decimal? MontoTotal { get; set; }
    }
}
