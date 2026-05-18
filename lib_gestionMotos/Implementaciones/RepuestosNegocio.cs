

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class RepuestosNegocio : IRepuestosNegocio
    {
        private IConexion? iConexion;
        public List<Repuestos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Repuestos",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los repuestos",
                UsuariosId = 1
            });

            return this.iConexion.Repuestos!.ToList();
        }

        public Repuestos Guardar(Repuestos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Repuestos",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el repuesto con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.Repuestos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Repuestos Modificar(Repuestos entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Repuestos",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el repuesto con id {entidad.Id}",
                UsuariosId = 1
            });


            var entry = this.iConexion!.Entry<Repuestos>(entidad);
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
                Entidad = "Repuestos",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el repuesto con id {id}",
                UsuariosId = 1
            });

            var entidad = new Repuestos();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<Repuestos>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
