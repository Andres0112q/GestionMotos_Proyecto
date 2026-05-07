

namespace lib_gestionMotos.Entidades
{
    public class PagoFacturas
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Comprobante { get; set; }
        public int FacturasId { get; set; }
        public int MetodosDePagosId { get; set; }

        public Facturas? _Facturas { get; set; }
        public MetodosDePagos? _MetodosDePagos { get; set; }


    }
}
