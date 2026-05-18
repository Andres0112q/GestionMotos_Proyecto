

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class OrdenComprasNegocio : IOrdenComprasNegocio
    {
        private IConexion? iConexion;
        public List<OrdenCompras> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Orden Compra",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las ordenes de compra",
                UsuariosId = 1
            });

            return this.iConexion.OrdenCompras!.ToList();
        }

        public OrdenCompras Guardar(OrdenCompras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Orden Compra",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó una orden de compra con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.OrdenCompras!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public OrdenCompras Modificar(OrdenCompras entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Orden Compra",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la orden de compra con id {entidad.Id}",
                UsuariosId = 1
            });


            var entry = this.iConexion!.Entry<OrdenCompras>(entidad);
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
                Entidad = "Orden Compra",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la orden de compra con id {id}",
                UsuariosId = 1
            });

            var entidad = new OrdenCompras();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<OrdenCompras>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
