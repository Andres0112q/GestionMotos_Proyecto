

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IDetalleOrdenComprasNegocio
    {
        List<DetalleOrdenCompras> Consultar();
        DetalleOrdenCompras Guardar(DetalleOrdenCompras entidad);
        DetalleOrdenCompras Modificar(DetalleOrdenCompras entidad);
        bool Borrar(int id);
    }
}
