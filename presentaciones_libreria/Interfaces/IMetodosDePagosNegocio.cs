
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IMetodosDePagosNegocio
    {
        List<MetodosDePagos> Consultar();
        MetodosDePagos Guardar(MetodosDePagos entidad);
        MetodosDePagos Modificar(MetodosDePagos entidad);
        bool Borrar(MetodosDePagos entidad);
    }
}
