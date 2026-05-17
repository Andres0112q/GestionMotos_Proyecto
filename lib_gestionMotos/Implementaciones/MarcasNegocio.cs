using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Entidades;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class MarcasNegocio : IMarcasNegocio
    {
        private IConexion? iConexion;
        //CRUD (CREATE, READ, UPDATE, DELETE)
        public List<Marcas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Marcas",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las marcas"
            });
            return this.iConexion.Marcas!.ToList();
        }

        public Marcas Guardar(Marcas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Marcas",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó la marca con id {entidad.Id}"
            });
            this.iConexion.Marcas!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Marcas Modificar(Marcas entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entry = this.iConexion.Entry<Marcas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Marcas",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la marca con id {entidad.Id}",
                UsuariosId = 1 
            });


            this.iConexion.SaveChanges();

            return entidad;
        }


        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Marcas",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la marca con id {id}"
            });
            var entidad = new Marcas();
            entidad.Id = id;
            var entry = this.iConexion.Entry<Marcas>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion.SaveChanges();

            return true;

        }


    }
}
