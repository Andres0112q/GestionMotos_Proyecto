using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IUnidadesDeMedidasNegocio
    {
        List<UnidadesDeMedidas> Consultar();
        UnidadesDeMedidas Guardar(UnidadesDeMedidas entidad);
        UnidadesDeMedidas Modificar(UnidadesDeMedidas entidad);
        UnidadesDeMedidas Borrar(UnidadesDeMedidas entidad);
    }
}
