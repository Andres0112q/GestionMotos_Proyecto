using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IUsuariosNegocio
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        bool Borrar(Usuarios entidad);
    }
}
