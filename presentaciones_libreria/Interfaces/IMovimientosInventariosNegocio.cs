using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IMovimientosInventariosNegocio
    {
        List<MovimientosInventarios> Consultar();
        MovimientosInventarios Guardar(MovimientosInventarios entidad);
        MovimientosInventarios Modificar(MovimientosInventarios entidad);
        bool Borrar(MovimientosInventarios entidad);
    }
}
