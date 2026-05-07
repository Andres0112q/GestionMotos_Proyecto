using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IDevolucionProveedoresNegocio
    {
        List<DevolucionProveedores> Consultar();
        DevolucionProveedores Guardar(DevolucionProveedores entidad);
        DevolucionProveedores Modificar(DevolucionProveedores entidad);
        DevolucionProveedores Borrar(DevolucionProveedores entidad);
    }
}
