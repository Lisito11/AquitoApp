using System;
using System.Collections.Generic;

namespace AquitoApi.Entities
{

        public partial class Factura606 : IId
        {
            public Factura606()
            {
                FacturasDetalle606 = new HashSet<FacturaDetalle606>();
            }

            public int Id { get; set; }
            public int? Age { get; set; }
            public int? Mes { get; set; }
            public int? Identification { get; set; }
            public int? Status { get; set; }
            public DateTime? EmisionDate { get; set; }

            public virtual ICollection<FacturaDetalle606> FacturasDetalle606 { get; set; }
        }
    
}
