

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IOrdenComprasNegocio
    {
        List<OrdenCompras> Consultar();
        OrdenCompras Guardar(OrdenCompras entidad);
        OrdenCompras Modificar(OrdenCompras entidad);
        bool Borrar(int id);
    }
}
