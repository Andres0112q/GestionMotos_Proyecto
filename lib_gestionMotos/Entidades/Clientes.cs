

namespace lib_gestionMotos.Entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public List<Facturas>? Facturas { get; set; }

    }
}
