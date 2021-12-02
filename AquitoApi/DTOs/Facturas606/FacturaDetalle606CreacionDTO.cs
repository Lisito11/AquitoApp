using System;

namespace AquitoApi.DTOs.Facturas606
{
    public class FacturaDetalle606CreacionDTO
    {
        public string Comprobante { get; set; }
        public DateTime? ComprobanteDate { get; set; }
        public DateTime? FechaPago { get; set; }
        public string FormaPago { get; set; }
        public string TypeVenta { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Itbis { get; set; }
        public int? Status { get; set; }
        public int? Factura606id { get; set; }
    }
}
