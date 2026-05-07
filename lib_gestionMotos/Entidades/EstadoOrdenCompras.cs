

namespace lib_gestionMotos.Entidades
{
    public class EstadoOrdenCompras
    {
        public int Id { get; set; }
        public string? Estado { get; set; }
        public List<OrdenCompras>? Ordenes { get; set; }
    }
}
