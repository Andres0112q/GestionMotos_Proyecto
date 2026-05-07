using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Schema;

namespace folder_unitarias;

[TestClass]
public class UnidadesDeMedidasUT
{
    private IConexion? iConexion;
    private UnidadesDeMedidas? entidad;

    [TestMethod]
    public void Ejecutar()
    {
        Consultar();
        Guardar();
        Modificar();
        Borrar();
    }

    private void Consultar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
        var lista = this.iConexion.UnidadesDeMedidas?.ToList();

        if (lista.Count > 0)
            return;
        throw new Exception("No se encontraron registros en la tabla UnidadesDeMedidas");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

        this.entidad = new UnidadesDeMedidas()
        {
            Sigla = "KG"    
        };
        this.iConexion.UnidadesDeMedidas?.Add(this.entidad);
        this.iConexion.SaveChanges();

        if (this.entidad.Id != 0)
            return;
        throw new Exception("");
    }


    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
        this.entidad!.Sigla = "LT";

        var entry = this.iConexion.Entry<UnidadesDeMedidas>(this.entidad!);
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

        this.iConexion.UnidadesDeMedidas?.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }

}
