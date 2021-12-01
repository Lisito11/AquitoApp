using System.Collections.Generic;

namespace AquitoApi.DTOs.Facturas607
{
    public class Factura607DTO: Factura607CreacionDTO
    {
        public int Id { get; set; }
        public virtual ICollection<FacturaDetalle607DTO> FacturasDetalle607 { get; set; }
    }
}
