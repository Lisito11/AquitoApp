using System;

namespace AquitoApi.Entities
{
    public partial class FacturaDetalle606 : IId
    {
        public int Id { get; set; }
        public int? Comprobante { get; set; }
        public DateTime? ComprobanteDate { get; set; }
        public DateTime? FechaPago { get; set; }
        public string FormaPago { get; set; }
        public string TypeVenta { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Itbis { get; set; }
        public int? Status { get; set; }
        public int? Factura606id { get; set; }
        public virtual Factura606 Factura606 { get; set; }

    }
}
