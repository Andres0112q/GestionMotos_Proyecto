

using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IDetalleOrdenComprasNegocio
    {
        List<DetalleOrdenCompras> Consultar();
        DetalleOrdenCompras Guardar(DetalleOrdenCompras entidad);
        DetalleOrdenCompras Modificar(DetalleOrdenCompras entidad);
        DetalleOrdenCompras Borrar(DetalleOrdenCompras entidad);
    }
}
