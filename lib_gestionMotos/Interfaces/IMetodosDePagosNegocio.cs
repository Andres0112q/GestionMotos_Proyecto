
using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IMetodosDePagosNegocio
    {
        List<MetodosDePagos> Consultar();
        MetodosDePagos Guardar(MetodosDePagos entidad);
        MetodosDePagos Modificar(MetodosDePagos entidad);
        bool Borrar(int id);
    }
}
