using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IGarantiasNegocio
    {
        List<Garantias> Consultar();
        Garantias Guardar(Garantias entidad);
        Garantias Modificar(Garantias entidad);
        bool Borrar(int id);
    }
}
