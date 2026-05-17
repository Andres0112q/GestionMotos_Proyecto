

using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IProveedoresNegocio
    {
        List<Proveedores> Consultar();
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        bool Borrar(Proveedores entidad);
    }
}
