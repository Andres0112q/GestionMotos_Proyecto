

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IRepuestosNegocio
    {
        List<Repuestos> Consultar();
        Repuestos Guardar(Repuestos entidad);
        Repuestos Modificar(Repuestos entidad);
        bool Borrar(int id);
    }
}
