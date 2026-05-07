
using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IFacturasNegocio
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);
        Facturas Modificar(Facturas entidad);
        bool Borrar(int id);
    }
}
