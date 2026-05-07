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

            return this.iConexion.Marcas!.ToList();
        }

        public Marcas Guardar(Marcas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

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
            this.iConexion.SaveChanges();

            return entidad;
        }


        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = new Marcas();
            entidad.Id = id;
            var entry = this.iConexion.Entry<Marcas>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion.SaveChanges();

            return true;

        }


    }
}
