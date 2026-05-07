using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IStockRepuestosNegocio
    {
        List<StockRepuestos> Consultar();
        StockRepuestos Guardar(StockRepuestos entidad);
        StockRepuestos Modificar(StockRepuestos entidad);
        StockRepuestos Borrar(StockRepuestos entidad);
    }
}
