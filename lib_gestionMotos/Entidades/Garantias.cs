

namespace lib_gestionMotos.Entidades
{
    public class Garantias
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int DuracionAños { get; set; }
        public string? DescripcionEstado { get; set; }
        public int MotosId { get; set; }

        public Motos? _Motos { get; set; }
    }
}
