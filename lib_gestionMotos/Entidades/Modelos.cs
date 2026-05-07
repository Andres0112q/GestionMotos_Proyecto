

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_gestionMotos.Entidades
{
    public class Modelos
    {
        public int Id { get; set; }
        public DateTime Año { get; set; }
        public string? Referencia { get; set; } 
        public string? Tipo { get; set; }
        public int MarcasId { get; set; }

        public Marcas? _Marcas { get; set; }
        public List<Motos>? Motos { get; set; }

    }
}
