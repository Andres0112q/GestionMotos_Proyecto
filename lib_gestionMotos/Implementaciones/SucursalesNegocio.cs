using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class SucursalesNegocio : ISucursalesNegocio
    {
        private IConexion? iConexion;
        public List<Sucursales> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Sucursales",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las sucursales",
                UsuariosId = 1
            });

            return this.iConexion.Sucursales!.ToList();
        }

        public Sucursales Guardar(Sucursales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Sucursales",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó la sucursal con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.Sucursales!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Sucursales Modificar(Sucursales entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Sucursales",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la sucursal con id {entidad.Id}",
                UsuariosId = 1
            });

            var entry = this.iConexion!.Entry<Sucursales>(entidad);
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
                Entidad = "Sucursales",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la sucursal con id {id}",
                UsuariosId = 1
            });

            var entidad = new Sucursales();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<Sucursales>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
        public List<Sucursales> PorDepartamento(string departamento)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            return this.iConexion.Sucursales!
                .Where(s => s.Ciudad == departamento).Include(x => x.InventarioMotos).ToList();
        }
    }
}
