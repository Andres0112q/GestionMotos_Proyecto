

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

            return this.iConexion.MovimientosInventarios!.ToList();
        }

        public MovimientosInventarios Guardar(MovimientosInventarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.MovimientosInventarios!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public MovimientosInventarios Modificar(MovimientosInventarios entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


            var entry = this.iConexion!.Entry<MovimientosInventarios>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return entidad;
        }

        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = new MovimientosInventarios();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<MovimientosInventarios>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
