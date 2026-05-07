using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace folder_unitarias;

[TestClass]
public class EstadoOrdenComprasUT
{
    private IConexion? iConexion;
    private EstadoOrdenCompras? entidad;


    [TestMethod]
    public void Ejecutar()
    {
        Guardar();
        Consultar();
        Modificar();
        Borrar();
    }

    private void Consultar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
        var lista = iConexion.EstadoOrdenCompras!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.entidad = new EstadoOrdenCompras()
        {
            Estado = "Pendiente"
        };
        this.iConexion.EstadoOrdenCompras!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (this.entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.entidad!.Estado = "Completado";

        var entry = this.iConexion!.Entry<EstadoOrdenCompras>(this.entidad!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.iConexion.EstadoOrdenCompras!.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }
}
