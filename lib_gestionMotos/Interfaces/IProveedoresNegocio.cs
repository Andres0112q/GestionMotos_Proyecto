

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IProveedoresNegocio
    {
        List<Proveedores> Consultar();
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        bool Borrar(int id);
    }
}
