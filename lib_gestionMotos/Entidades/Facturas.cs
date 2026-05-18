

using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public decimal TotalPagado
        {
            get
            {
                if (Pagos == null || !Pagos.Any())
                    return 0;
                return Pagos.Sum(p => p.Monto);
            }
        }
        [NotMapped]
        public decimal SaldoPendiente
        {
            get { return Total - TotalPagado; }
        }
        [NotMapped]
        public string Estado
        {
            get
            {
                if (SaldoPendiente <= 0)
                    return "Pagada";
                else
                    return "Pendiente";
            }
        }

    }
}
