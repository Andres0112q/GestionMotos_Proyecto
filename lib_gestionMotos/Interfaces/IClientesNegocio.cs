

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IClientesNegocio
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        bool Borrar(int id);

    }
}
