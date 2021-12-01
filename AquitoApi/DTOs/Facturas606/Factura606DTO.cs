using System.Collections.Generic;

namespace AquitoApi.DTOs.Facturas606
{
    public class Factura606DTO:Factura606CreacionDTO
    {
        public int Id { get; set; }
        public virtual ICollection<FacturaDetalle606DTO> FacturasDetalle606 { get; set; }
    }
}
