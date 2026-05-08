
namespace lib_gestionMotos.Entidades
{
    public class Sucursales
    {
        public int Id { get; set; }
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }

        public List<InventarioMotos>? InventarioMotos { get; set; }

    }
}
