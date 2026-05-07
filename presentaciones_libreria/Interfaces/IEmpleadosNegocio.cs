
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IEmpleadosNegocio
    {
        List<Empleados> Consultar();
        Empleados Guardar(Empleados entidad);
        Empleados Modificar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
    }
}
