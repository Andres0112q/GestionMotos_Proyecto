
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IEstadoOrdenComprasNegocio
    {
        List<EstadoOrdenCompras> Consultar();
        EstadoOrdenCompras Guardar(EstadoOrdenCompras entidad);
        EstadoOrdenCompras Modificar(EstadoOrdenCompras entidad);
        EstadoOrdenCompras Borrar(EstadoOrdenCompras entidad);
    }
}
