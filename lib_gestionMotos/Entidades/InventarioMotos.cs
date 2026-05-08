

namespace lib_gestionMotos.Entidades
{
    public class InventarioMotos
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string? Estado { get; set; }
        public int MotosId { get; set; }
        public int SucursalesId { get; set; }
        public DateTime UltimoConteo { get; set; }

        public Motos? _Motos { get; set; }
        public Sucursales? _Sucursales { get; set; }
    }
}
