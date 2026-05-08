using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface ISucursalesNegocio
    {
        List<Sucursales> Consultar();
        Sucursales Guardar(Sucursales entidad);
        Sucursales Modificar(Sucursales entidad);
        bool Borrar(int id);
    }
}
