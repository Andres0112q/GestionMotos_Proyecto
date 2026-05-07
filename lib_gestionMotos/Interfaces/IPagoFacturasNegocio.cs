

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IPagoFacturasNegocio
    {
        List<PagoFacturas> Consultar();
        PagoFacturas Guardar(PagoFacturas entidad);
        PagoFacturas Modificar(PagoFacturas entidad);
        bool Borrar(int id);
    }
}
