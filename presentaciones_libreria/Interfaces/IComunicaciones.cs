

namespace presentaciones_libreria.Interfaces
{
    public interface IComunicaciones
    {
        Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos);
    }
}
