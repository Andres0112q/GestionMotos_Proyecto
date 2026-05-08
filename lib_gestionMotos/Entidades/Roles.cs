

namespace lib_gestionMotos.Entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public List<Usuarios>? Usuarios { get; set; }
    }
}
