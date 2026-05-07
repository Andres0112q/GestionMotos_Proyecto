using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class EstadoOrdenComprasNegocio : IEstadoOrdenComprasNegocio
    {
       
            private IConexion? iConexion;
            public List<EstadoOrdenCompras> Consultar()
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                return this.iConexion.EstadoOrdenCompras!.ToList();
            }

            public EstadoOrdenCompras Guardar(EstadoOrdenCompras entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                this.iConexion.EstadoOrdenCompras!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public EstadoOrdenCompras Modificar(EstadoOrdenCompras entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


                var entry = this.iConexion!.Entry<EstadoOrdenCompras>(entidad);
                entry.State = EntityState.Modified;
                this.iConexion!.SaveChanges();

                return entidad;
            }

            public bool Borrar(int id)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                var entidad = new EstadoOrdenCompras();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<EstadoOrdenCompras>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }


