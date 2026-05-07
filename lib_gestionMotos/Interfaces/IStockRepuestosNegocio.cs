

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IStockRepuestosNegocio
    {
        List<StockRepuestos> Consultar();
        StockRepuestos Guardar(StockRepuestos entidad);
        StockRepuestos Modificar(StockRepuestos entidad);
        bool Borrar(int id);
    }
}
