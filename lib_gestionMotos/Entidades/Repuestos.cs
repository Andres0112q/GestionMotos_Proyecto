
namespace lib_gestionMotos.Entidades
{
    public class Repuestos
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaRepuestosId { get; set; }
        public string? PasilloUbicacion { get; set; }

        public CategoriaRepuestos? _CategoriaRepuestos { get; set; }
        public List<StockRepuestos>? HistorialStock { get; set; }
        public List<DetalleOrdenCompras>? DetallesOrden { get; set; }
        public List<DetalleDevoluciones>? DetallesDevolucion { get; set; }
    }
}
