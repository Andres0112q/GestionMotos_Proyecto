namespace lib_gestionMotos.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Entidad { get; set; }
        public string? Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        public int UsuariosId { get; set; }

        public Usuarios? _Usuarios { get; set; }
    }
}
