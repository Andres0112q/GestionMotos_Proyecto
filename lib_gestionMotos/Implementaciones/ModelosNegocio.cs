

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class ModelosNegocio : IModelosNegocio
    {
            private IConexion? iConexion;
            public List<Modelos> Consultar()
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Modelos",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los modelos",
                UsuariosId = 1
            });
            return this.iConexion.Modelos!.ToList();
            }

            public Modelos Guardar(Modelos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Modelos",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el modelo con id {entidad.Id}",
                UsuariosId = 1
            });
            this.iConexion.Modelos!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public Modelos Modificar(Modelos entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Modelos",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el modelo con id {entidad.Id}",
                UsuariosId = 1
            });

            var entry = this.iConexion!.Entry<Modelos>(entidad);
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
                Entidad = "Modelos",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el modelo con id {id}",
                UsuariosId = 1
            });
            var entidad = new Modelos();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<Modelos>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }

