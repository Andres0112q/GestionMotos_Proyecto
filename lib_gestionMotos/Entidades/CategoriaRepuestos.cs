

namespace lib_gestionMotos.Entidades
{
    public class CategoriaRepuestos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public List<Repuestos>? Repuestos { get; set; }

    }
}
