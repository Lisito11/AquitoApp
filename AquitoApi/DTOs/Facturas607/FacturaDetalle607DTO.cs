namespace AquitoApi.DTOs.Facturas607
{
    public class FacturaDetalle607DTO: FacturaDetalle607CreacionDTO
    {
        public int Id { get; set; }
        public virtual Factura607DTO Factura607 { get; set; }
    }
}
