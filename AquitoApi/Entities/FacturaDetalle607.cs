using System;

namespace AquitoApi.Entities
{
    public partial class FacturaDetalle607 : IId
    {

        public int Id { get; set; }
        public string Comprobante { get; set; }
        public DateTime? ComprobanteDate { get; set; }
        public string TypeIncome { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Itbis { get; set; }
        public int? Status { get; set; }
        public int? factura607id { get; set; }
        public virtual Factura607 Factura607 { get; set; }

    }
}
