using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface IAuditoriasNegocio
    {
        List<Auditorias> Consultar();
        Auditorias Guardar(Auditorias entidad);
        Auditorias Modificar(Auditorias entidad);
        bool Borrar(int id);
    }
}
