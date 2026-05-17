using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface IGarantiasNegocio
    {
        List<Garantias> Consultar();
        Garantias Guardar(Garantias entidad);
        Garantias Modificar(Garantias entidad);
        bool Borrar(Garantias entidad);
        Garantias ActualizacionDescripcion (Garantias entidad);
    }
}
