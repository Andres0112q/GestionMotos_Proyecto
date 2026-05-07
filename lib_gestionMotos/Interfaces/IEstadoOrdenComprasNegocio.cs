

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IEstadoOrdenComprasNegocio
    {
        List<EstadoOrdenCompras> Consultar();
        EstadoOrdenCompras Guardar(EstadoOrdenCompras entidad);
        EstadoOrdenCompras Modificar(EstadoOrdenCompras entidad);
        bool Borrar(int id);
    }
}
