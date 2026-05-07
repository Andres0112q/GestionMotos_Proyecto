
namespace lib_gestionMotos.Entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }

        public List<OrdenCompras>? Ordenes { get; set; }
        public List<DevolucionProveedores>? Devoluciones { get; set; }
    }
}
