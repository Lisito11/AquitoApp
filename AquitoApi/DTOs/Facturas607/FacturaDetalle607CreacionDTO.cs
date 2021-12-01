using System;

namespace AquitoApi.DTOs.Facturas607
{
    public class FacturaDetalle607CreacionDTO
    {
        public int? Comprobante { get; set; }
        public DateTime? ComprobanteDate { get; set; }
        public string TypeIncome { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Itbis { get; set; }
        public int? Status { get; set; }
        public int? Factura607id { get; set; }
    }
}
