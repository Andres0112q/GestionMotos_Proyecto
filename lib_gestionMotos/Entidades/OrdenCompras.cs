
namespace lib_gestionMotos.Entidades
{
    public class OrdenCompras
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public decimal Total { get; set; }
        public int? ProveedoresId { get; set; }
        public int? EstadoOrdenComprasId { get; set; }
        public DateTime FechaEmision { get; set; }

        public Proveedores? _Proveedores { get; set; }
        public EstadoOrdenCompras? _EstadoOrdenCompras { get; set; }
        public List<DetalleOrdenCompras>? Detalles { get; set; }
    }
}
