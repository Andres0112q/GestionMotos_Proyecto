using lib_gestionMotos.Entidades;


namespace lib_gestionMotos.Interfaces
{
    public interface IUnidadesDeMedidasNegocio
    {
        List<UnidadesDeMedidas> Consultar();
        UnidadesDeMedidas Guardar(UnidadesDeMedidas entidad);
        UnidadesDeMedidas Modificar(UnidadesDeMedidas entidad);
        bool Borrar(int id);


    }
}
