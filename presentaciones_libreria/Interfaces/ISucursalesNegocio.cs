
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface ISucursalesNegocio
    {
        List<Sucursales> Consultar();
        Sucursales Guardar(Sucursales entidad);
        Sucursales Modificar(Sucursales entidad);
        bool Borrar(Sucursales entidad);
        List<Sucursales> PorDepartamento(string departamento);
    }
}
