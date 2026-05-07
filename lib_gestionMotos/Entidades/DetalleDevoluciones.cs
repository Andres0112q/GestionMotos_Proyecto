

namespace lib_gestionMotos.Entidades
{
    public class DetalleDevoluciones
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string? Defecto { get; set; }
        public int RepuestosId { get; set; }
        public int DevolucionProveedoresId { get; set; }
        public bool RequiereCambio { get; set; }

        public DevolucionProveedores? _DevolucionProveedores { get; set; }
        public Repuestos? _Repuesto { get; set; }

    }
}
