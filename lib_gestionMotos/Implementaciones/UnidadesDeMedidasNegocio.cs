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
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Unidades de medidas",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las unidades de medidas",
                UsuariosId = 1
            });

            return this.iConexion.UnidadesDeMedidas!.ToList();

        }

        public UnidadesDeMedidas Guardar(UnidadesDeMedidas entidad)
        {
            if(entidad.Id != 0)
                throw new Exception("Ya se guardo");
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Unidades de medidas",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó la unidad de medida con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.UnidadesDeMedidas!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public UnidadesDeMedidas Modificar (UnidadesDeMedidas entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Unidades de medidas",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la unidad de medida con id {entidad.Id}",
                UsuariosId = 1
            });

            var entry = this.iConexion.Entry<UnidadesDeMedidas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();

            return entidad;
        }


        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Unidades de medidas",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la unidad de medida con id {id}",
                UsuariosId = 1
            });

            var entidad = new UnidadesDeMedidas();
            entidad.Id = id;
            var entry = this.iConexion.Entry<UnidadesDeMedidas>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion.SaveChanges();
            return true;
        }

    }
}
