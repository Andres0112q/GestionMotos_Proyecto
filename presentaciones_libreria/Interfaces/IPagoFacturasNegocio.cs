using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IPagoFacturasNegocio
    {
        List<PagoFacturas> Consultar();
        PagoFacturas Guardar(PagoFacturas entidad);
        PagoFacturas Modificar(PagoFacturas entidad);
        bool Borrar(PagoFacturas entidad);
    }
}
