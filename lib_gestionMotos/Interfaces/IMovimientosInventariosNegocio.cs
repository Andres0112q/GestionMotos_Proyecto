

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IMovimientosInventariosNegocio
    {
        List<MovimientosInventarios> Consultar();
        MovimientosInventarios Guardar(MovimientosInventarios entidad);
        MovimientosInventarios Modificar(MovimientosInventarios entidad);
        bool Borrar(int id);
    }
}
