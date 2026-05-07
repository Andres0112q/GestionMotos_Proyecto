
using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IInventarioMotosNegocio
    {
        List<InventarioMotos> Consultar();
        InventarioMotos Guardar(InventarioMotos entidad);
        InventarioMotos Modificar(InventarioMotos entidad);
        bool Borrar(int id);
    }
}
