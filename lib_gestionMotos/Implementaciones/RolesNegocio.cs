using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class RolesNegocio : IRolesNegocio
    {
        private IConexion? iConexion;
        public List<Roles> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Roles",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los roles",
                UsuariosId = 1
            });

            return this.iConexion.Roles!.ToList();
        }

        public Roles Guardar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Roles",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el rol con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.Roles!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Roles Modificar(Roles entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Roles",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el rol con id {entidad.Id}",
                UsuariosId = 1
            });


            var entry = this.iConexion!.Entry<Roles>(entidad);
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
                Entidad = "Roles",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el rol con id {id}",
                UsuariosId = 1
            });

            var entidad = new Roles();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
