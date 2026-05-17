using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IDevolucionProveedoresNegocio
    {
        List<DevolucionProveedores> Consultar();
        DevolucionProveedores Guardar(DevolucionProveedores entidad);
        DevolucionProveedores Modificar(DevolucionProveedores entidad);
        bool Borrar(DevolucionProveedores entidad);
    }
}
