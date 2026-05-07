
namespace lib_gestionMotos.Entidades
{
    public class StockRepuestos
    {
        public int Id { get; set; }
        public int Actual { get; set; }
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public int RepuestosId { get; set; }
        public DateTime UltimaRevision { get; set; }

        public Repuestos? _Repuestos { get; set; }
    }
}
