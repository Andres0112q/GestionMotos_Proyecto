
using lib_gestionMotos.Entidades;

namespace presentaciones_libreria.Interfaces
{
    public interface ICategoriaRepuestosNegocio
    {
        List<CategoriaRepuestos> Consultar();
        CategoriaRepuestos Guardar(CategoriaRepuestos entidad);
        CategoriaRepuestos Modificar(CategoriaRepuestos entidad);
        CategoriaRepuestos Borrar(CategoriaRepuestos entidad);
    }
}
