using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace lib_gestionMotos.Implementaciones
{
    public class UnidadesDeMedidasNegocio : IUnidadesDeMedidasNegocio
    {
        private IConexion? iConexion;

        public List<UnidadesDeMedidas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            return this.iConexion.UnidadesDeMedidas!.ToList();

        }

        public UnidadesDeMedidas Guardar(UnidadesDeMedidas entidad)
        {
            if(entidad.Id != 0)
                throw new Exception("Ya se guardo");
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.UnidadesDeMedidas!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public UnidadesDeMedidas Modificar (UnidadesDeMedidas entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entry = this.iConexion.Entry<UnidadesDeMedidas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();

            return entidad;
        }


        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = new UnidadesDeMedidas();
            entidad.Id = id;
            var entry = this.iConexion.Entry<UnidadesDeMedidas>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion.SaveChanges();
            return true;
        }

    }
}
