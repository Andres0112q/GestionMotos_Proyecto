

namespace lib_gestionMotos.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public string? Cargo { get; set; }
        public string? Telefono { get; set; }
        public List<MovimientosInventarios>? Movimientos { get; set; }
        public List<Facturas>? Ventas { get; set; }
    }
}
