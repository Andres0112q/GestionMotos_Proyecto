
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IDetalleDevolucionesNegocio
    {
        List<DetalleDevoluciones> Consultar();
        DetalleDevoluciones Guardar(DetalleDevoluciones entidad);
        DetalleDevoluciones Modificar(DetalleDevoluciones entidad);
        bool Borrar(DetalleDevoluciones entidad);
    }
}
