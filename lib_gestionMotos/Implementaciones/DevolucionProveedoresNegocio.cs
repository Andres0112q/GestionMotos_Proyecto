

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class DevolucionProveedoresNegocio : IDevolucionProveedoresNegocio
    {
        private IConexion? iConexion;
        public List<DevolucionProveedores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            return this.iConexion.DevolucionProveedores!.ToList();
        }

        public DevolucionProveedores Guardar(DevolucionProveedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.DevolucionProveedores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public DevolucionProveedores Modificar(DevolucionProveedores entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


            var entry = this.iConexion!.Entry<DevolucionProveedores>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return entidad;
        }

        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = new DevolucionProveedores();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<DevolucionProveedores>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
