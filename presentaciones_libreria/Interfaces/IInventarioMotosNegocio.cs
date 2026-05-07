
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IInventarioMotosNegocio
    {
        List<InventarioMotos> Consultar();
        InventarioMotos Guardar(InventarioMotos entidad);
        InventarioMotos Modificar(InventarioMotos entidad);
        InventarioMotos Borrar(InventarioMotos entidad);
    }
}
