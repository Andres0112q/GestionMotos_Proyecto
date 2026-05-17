using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IOrdenComprasNegocio
    {
        List<OrdenCompras> Consultar();
        OrdenCompras Guardar(OrdenCompras entidad);
        OrdenCompras Modificar(OrdenCompras entidad);
        bool Borrar(OrdenCompras entidad);
    }
}
