

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class DetalleOrdenComprasNegocio : IDetalleOrdenComprasNegocio
    {
        private IConexion? iConexion;
        public List<DetalleOrdenCompras> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Detalle Orden Compras",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los detalles de orden de compras"
            });

            return this.iConexion.DetalleOrdenCompras!.ToList();
        }

        public DetalleOrdenCompras Guardar(DetalleOrdenCompras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Detalle Orden Compras",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el detalle de orden de compras con id {entidad.Id}"
            });

            this.iConexion.DetalleOrdenCompras!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public DetalleOrdenCompras Modificar(DetalleOrdenCompras entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Detalle Orden Compras",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el detalle de orden de compras con id {entidad.Id}"
            });


            var entry = this.iConexion!.Entry<DetalleOrdenCompras>(entidad);
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
                Entidad = "Detalle Orden Compras",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el detalle de orden de compras con id {id}"
            });

            var entidad = new DetalleOrdenCompras();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<DetalleOrdenCompras>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }


    }
}
