

namespace lib_gestionMotos.Entidades
{
    public class InventarioMotos
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string? Estado { get; set; }
        public int MotosId { get; set; }
        public DateTime UltimoConteo { get; set; }

        public Motos? _Motos { get; set; }
    }
}
