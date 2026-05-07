

namespace lib_gestionMotos.Entidades
{
    public class Marcas
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Referencia { get; set; }
        public List<Motos>? Motos { get; set; }
        public List<Modelos>? Modelos { get; set; }

    }

}
