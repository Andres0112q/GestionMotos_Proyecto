using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IMarcasNegocio
    {
        List<Marcas> Consultar();
        Marcas Guardar(Marcas entidad);
        Marcas Modificar(Marcas entidad);
        bool Borrar(int id);

    }
}
