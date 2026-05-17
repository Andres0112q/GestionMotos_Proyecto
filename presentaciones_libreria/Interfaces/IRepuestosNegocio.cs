using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IRepuestosNegocio
    {
        List<Repuestos> Consultar();
        Repuestos Guardar(Repuestos entidad);
        Repuestos Modificar(Repuestos entidad);
        bool Borrar(Repuestos entidad);
    }
}
