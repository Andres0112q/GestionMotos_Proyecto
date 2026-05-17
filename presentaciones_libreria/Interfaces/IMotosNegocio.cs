
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IMotosNegocio
    {
        List<Motos> Consultar();
        Motos Guardar(Motos entidad);
        Motos Modificar(Motos entidad);
        bool Borrar(Motos entidad);
    }
}
