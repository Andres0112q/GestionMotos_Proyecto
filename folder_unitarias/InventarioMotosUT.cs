using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace folder_unitarias;

[TestClass]
public class InventarioMotosUT
{
    private IConexion? iConexion;
    private InventarioMotos? entidad;


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
        var lista = iConexion.InventarioMotos!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.entidad = new InventarioMotos()
        {
            Cantidad = 5,
            Estado = "Disponible",
            MotosId = 1,
            UltimoConteo = DateTime.Now.AddDays(-2)
        };
        this.iConexion.InventarioMotos!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (this.entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.entidad!.Cantidad = 10;

        var entry = this.iConexion!.Entry<InventarioMotos>(this.entidad!);
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

        this.iConexion.InventarioMotos!.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }
}
