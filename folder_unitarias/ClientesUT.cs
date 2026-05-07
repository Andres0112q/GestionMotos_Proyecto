using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_gestionMotos.Nucleo;

namespace folder_unitarias;

[TestClass]
public class ClientesUT
{
    private IConexion? iConexion;
    private Clientes? entidad;


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
        var lista = iConexion.Clientes!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.entidad = new Clientes()
        {
            Nombre = "Roberto Gimenez",
            Cedula = "10927343",
            Telefono = "314562364",
            Correo = "roberto@gmail.com"
        };
        this.iConexion.Clientes!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (this.entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.entidad!.Nombre = "Miguel Gimenez";

        var entry = this.iConexion!.Entry<Clientes>(this.entidad!);
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

        this.iConexion.Clientes!.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }
}
