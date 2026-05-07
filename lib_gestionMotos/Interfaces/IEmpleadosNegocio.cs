
using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IEmpleadosNegocio
    {
        List<Empleados> Consultar();
        Empleados Guardar(Empleados entidad);
        Empleados Modificar(Empleados entidad);
        bool Borrar(int id);
    }
}
