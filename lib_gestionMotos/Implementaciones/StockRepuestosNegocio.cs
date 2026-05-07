

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class StockRepuestosNegocio : IStockRepuestosNegocio
    {
        private IConexion? iConexion;
        public List<StockRepuestos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            return this.iConexion.StockRepuestos!.ToList();
        }

        public StockRepuestos Guardar(StockRepuestos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.StockRepuestos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public StockRepuestos Modificar(StockRepuestos entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


            var entry = this.iConexion!.Entry<StockRepuestos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return entidad;
        }

        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = new StockRepuestos();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<StockRepuestos>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
