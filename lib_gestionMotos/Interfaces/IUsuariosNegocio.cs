using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IUsuariosNegocio
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        bool Borrar(int id);
    }
}
