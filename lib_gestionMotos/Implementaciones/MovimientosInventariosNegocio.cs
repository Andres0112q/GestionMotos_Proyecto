

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class MovimientosInventariosNegocio : IMovimientosInventariosNegocio
    {
        private IConexion? iConexion;
        public List<MovimientosInventarios> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Movimientos Inventarios",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los movimientos de inventario",
                UsuariosId = 1
            });

            return this.iConexion.MovimientosInventarios!.ToList();
        }

        public MovimientosInventarios Guardar(MovimientosInventarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Movimientos Inventarios",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el movimiento de inventario con id {entidad.Id}",
                UsuariosId = 1
            });
            this.iConexion.MovimientosInventarios!.Add(entidad!);
            this.iConexion.SaveChanges();

            var inventario = this.iConexion.InventarioMotos!.FirstOrDefault
                (x => x.Id == entidad.InventarioMotosId);
            if (inventario == null)
                throw new Exception("No existe inventario para esa moto");
            if(entidad.Tipo == "Entrada")
            {
                inventario.Cantidad += entidad.Cantidad;
            }
            else if(entidad.Tipo == "Salida")
            {
                if (inventario.Cantidad < entidad.Cantidad)
                    throw new Exception("No hay suficiente stock");
                inventario.Cantidad -= entidad.Cantidad;
            }
            inventario.UltimoConteo = DateTime.Now;
            var negocioInventario = new InventarioMotosNegocio();
            negocioInventario.ModificarEstado(inventario);

            return entidad;
        }
        public MovimientosInventarios Modificar(MovimientosInventarios entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Movimientos Inventarios",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el movimiento de inventario con id {entidad.Id}",
                UsuariosId = 1
            });

            var entry = this.iConexion!.Entry<MovimientosInventarios>(entidad);
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
                Entidad = "Movimientos Inventarios",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el movimiento de inventario con id {id}",
                UsuariosId = 1
            });
            var entidad = new MovimientosInventarios();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<MovimientosInventarios>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
