

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class DetalleDevolucionesNegocio : IDetalleDevolucionesNegocio
    {
        private IConexion? iConexion;
        public List<DetalleDevoluciones> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Detalle Devoluciones",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los detalles de devoluciones",
                UsuariosId = 1
            });

            return this.iConexion.DetalleDevoluciones!.ToList();
        }

        public DetalleDevoluciones Guardar(DetalleDevoluciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Detalle Devoluciones",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el detalle de devoluciones con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.DetalleDevoluciones!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public DetalleDevoluciones Modificar(DetalleDevoluciones entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Detalle Devoluciones",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el detalle de devoluciones con id {entidad.Id}",
                UsuariosId = 1
            });


            var entry = this.iConexion!.Entry<DetalleDevoluciones>(entidad);
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
                Entidad = "Detalle Devoluciones",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el detalle de devoluciones con id {id}",
                UsuariosId = 1
            });

            var entidad = new DetalleDevoluciones();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<DetalleDevoluciones>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}
