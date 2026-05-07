
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IMarcasNegocio
    {
        List<Marcas> Consultar();
        Marcas Guardar(Marcas entidad);
        Marcas Modificar(Marcas entidad);
        Marcas Borrar(Marcas entidad);
    }
}
