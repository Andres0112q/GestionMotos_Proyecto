

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IModelosNegocio
    {
        List<Modelos> Consultar();
        Modelos Guardar(Modelos entidad);
        Modelos Modificar(Modelos entidad);
        bool Borrar(int id);
    }
}
