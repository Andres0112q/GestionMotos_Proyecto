

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
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Devolucion Proveedores",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las devoluciones de proveedores",
                UsuariosId = 1
            });

            return this.iConexion.DevolucionProveedores!.ToList();
        }

        public DevolucionProveedores Guardar(DevolucionProveedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Devolucion Proveedores",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó la devolución de proveedores con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.DevolucionProveedores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public DevolucionProveedores Modificar(DevolucionProveedores entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Devolucion Proveedores",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la devolución de proveedores con id {entidad.Id}",
                UsuariosId = 1
            });


            var entry = this.iConexion!.Entry<DevolucionProveedores>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return entidad;
        }

        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Devolucion Proveedores",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la devolución de proveedores con id {id}",
                UsuariosId = 1
            });

            var entidad = new DevolucionProveedores();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<DevolucionProveedores>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
