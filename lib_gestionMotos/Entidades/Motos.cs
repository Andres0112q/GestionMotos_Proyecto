
namespace lib_gestionMotos.Entidades
{
    public class Motos
    {
        public int Id { get; set; }
        public string? Placa { get; set; }
        public int ModelosId { get; set; }
        public int MarcasId { get; set; }
        public decimal Valor { get; set; }

        public Modelos? _Modelos { get; set; }
        public Marcas? _Marcas { get; set; }
        public List<InventarioMotos>? Inventarios { get; set; }
        public List<Garantias>? Garantias { get; set; }
        
    }
}
