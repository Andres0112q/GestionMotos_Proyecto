

namespace lib_gestionMotos.Entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public decimal Total { get; set; }
        public int ClientesId { get; set; }
        public int EmpleadosId { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Clientes? _Clientes { get; set; }
        public Empleados? _Empleados { get; set; }
        public List<PagoFacturas>? Pagos { get; set; }

    }
}
