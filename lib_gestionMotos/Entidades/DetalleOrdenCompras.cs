

namespace lib_gestionMotos.Entidades
{
    public class DetalleOrdenCompras
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public int RepuestosId { get; set; }
        public int OrdenComprasId { get; set; }
        public decimal PrecioUnitario { get; set; }

        public OrdenCompras? _OrdenCompras { get; set; }
        public Repuestos? _Repuestos { get; set; }


    }
}
