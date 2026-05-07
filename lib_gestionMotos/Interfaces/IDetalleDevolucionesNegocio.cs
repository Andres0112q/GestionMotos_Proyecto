

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IDetalleDevolucionesNegocio
    {
        List<DetalleDevoluciones> Consultar();
        DetalleDevoluciones Guardar(DetalleDevoluciones entidad);
        DetalleDevoluciones Modificar(DetalleDevoluciones entidad);
        bool Borrar(int id);
    }
}
