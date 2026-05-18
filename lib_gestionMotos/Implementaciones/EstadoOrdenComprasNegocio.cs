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
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Estado Orden Compras",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los estados de orden de compras",
                UsuariosId = 1
            });

            return this.iConexion.EstadoOrdenCompras!.ToList();
            }

            public EstadoOrdenCompras Guardar(EstadoOrdenCompras entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Estado Orden Compras",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el estado de orden de compras con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.EstadoOrdenCompras!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public EstadoOrdenCompras Modificar(EstadoOrdenCompras entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Estado Orden Compras",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el estado de orden de compras con id {entidad.Id}",
                UsuariosId = 1
            });


            var entry = this.iConexion!.Entry<EstadoOrdenCompras>(entidad);
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
                Entidad = "Estado Orden Compras",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el estado de orden de compras con id {id}",
                UsuariosId = 1
            });

            var entidad = new EstadoOrdenCompras();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<EstadoOrdenCompras>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }


