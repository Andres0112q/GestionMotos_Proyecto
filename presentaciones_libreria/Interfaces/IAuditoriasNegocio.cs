

using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IAuditoriasNegocio
    {
        List<Auditorias> Consultar();
        Auditorias Guardar(Auditorias entidad);
        Auditorias Modificar(Auditorias entidad);
        bool Borrar(Auditorias entidad);
    }
}
