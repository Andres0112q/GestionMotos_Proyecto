

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IMotosNegocio
    {
        List<Motos> Consultar();
        Motos Guardar(Motos entidad);
        Motos Modificar(Motos entidad);
        bool Borrar(int id);
    }
}
