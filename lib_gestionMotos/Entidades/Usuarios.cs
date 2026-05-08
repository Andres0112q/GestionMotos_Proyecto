
namespace lib_gestionMotos.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }     
        public string? Nombre { get; set; }
        public string? Contraseña { get; set; }
        public int RolesId { get; set; }

        public Roles? _Roles { get; set; }
        public List<Auditorias>? Auditorias { get; set; }
    }
}
