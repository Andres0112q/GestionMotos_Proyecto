

using lib_gestionMotos.Entidades;

namespace lib_gestionMotos.Interfaces
{
    public interface ICategoriaRepuestosNegocio
    {
        List<CategoriaRepuestos> Consultar();
        CategoriaRepuestos Guardar(CategoriaRepuestos entidad);
        CategoriaRepuestos Modificar(CategoriaRepuestos entidad);
        bool Borrar(int id);
    }
}
