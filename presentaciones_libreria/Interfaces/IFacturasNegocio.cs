
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IFacturasNegocio
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);
        Facturas Modificar(Facturas entidad);
        Facturas Borrar(Facturas entidad);
    }
}
