namespace AquitoApi.DTOs.Facturas606
{
    public class FacturaDetalle606DTO: FacturaDetalle606CreacionDTO
    {
        public int Id { get; set; }
        public virtual Factura606DTO Factura606 { get; set; }

    }
}
