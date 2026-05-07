

namespace lib_gestionMotos.Entidades
{
    public class MetodosDePagos
    {
        public int Id { get; set; }
        public string? Metodo { get; set; }
        public string? Descripcion { get; set; }
        public bool EsDigital { get; set; }
        public string? ReferenciaInterna { get; set; }
        public List<PagoFacturas>? Pagos { get; set; }
    }
}
