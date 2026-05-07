

namespace lib_gestionMotos.Entidades
{
    public class MovimientosInventarios
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadosId { get; set; }
        public string? AlmacenOrigen { get; set; }

        public Empleados? _Empleados { get; set; }
    }
}
