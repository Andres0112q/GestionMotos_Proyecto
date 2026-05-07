

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IDevolucionProveedoresNegocio
    {
        List<DevolucionProveedores> Consultar();
        DevolucionProveedores Guardar(DevolucionProveedores entidad);
        DevolucionProveedores Modificar(DevolucionProveedores entidad);
        bool Borrar(int id);
    }
}
