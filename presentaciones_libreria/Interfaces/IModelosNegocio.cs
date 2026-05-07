using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IModelosNegocio
    {
        List<Modelos> Consultar();
        Modelos Guardar(Modelos entidad);
        Modelos Modificar(Modelos entidad);
        Modelos Borrar(Modelos entidad);
    }
}
