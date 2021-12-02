using System;
using System.Collections.Generic;

namespace AquitoApi.Entities
{

    public partial class Factura607 : IId
    {
        public Factura607()
        {
            FacturasDetalle607 = new HashSet<FacturaDetalle607>();
        }

        public int Id { get; set; }
        public string Age { get; set; }
        public int? Mes { get; set; }
        public string Identification { get; set; }
        public int? Status { get; set; }
        public DateTime? EmisionDate { get; set; }

        public virtual ICollection<FacturaDetalle607> FacturasDetalle607 { get; set; }
    }

}