using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_gestionMotos.Nucleo;
using System.ComponentModel;

namespace folder_unitarias;

[TestClass]
public class MetodosDePagosUT
{
    
    private IConexion? iConexion;
    private MetodosDePagos? entidad;

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
        var lista = iConexion.MetodosDePagos!.ToList();

        if (lista.Count > 0)
            return;
        throw new Exception("No implementado");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.entidad = new MetodosDePagos()
        {
            Metodo = "Efectivo",
            Descripcion = "Pago en efectivo",
            EsDigital = false,
            ReferenciaInterna = "EFECTIVO001"
        };
        this.iConexion.MetodosDePagos!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (entidad.Id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
        this.entidad!.Metodo = "Tarjeta de Crédito";

        var entry = this.iConexion.Entry<MetodosDePagos>(this.entidad!);
        entry.State = EntityState.Modified;
        this.iConexion.SaveChanges();

        if (entidad.Id != 0)
            return;
        throw new Exception("");
    }


    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.iConexion.MetodosDePagos!.Remove(this.entidad!);
        this.iConexion.SaveChanges();

    }
}

