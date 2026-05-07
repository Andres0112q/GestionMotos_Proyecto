

namespace lib_gestionMotos.Entidades
{
    public class DevolucionProveedores
    {
        public int Id { get; set; }
        public string? Radicado { get; set; }
        public string? Motivo { get; set; }
        public int ProveedoresId { get; set; }
        public decimal Reembolso { get; set; }
        public string? EstadoTramite { get; set; }

        public Proveedores? _Proveedores { get; set; }
        public List<DetalleDevoluciones>? Detalles { get; set; }
    }
}
