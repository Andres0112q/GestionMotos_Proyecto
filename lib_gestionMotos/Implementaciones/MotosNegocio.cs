

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class MotosNegocio : IMotosNegocio
    {
      
            private IConexion? iConexion;
            public List<Motos> Consultar()
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Motos",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las motos",
                UsuariosId = 1
            });

            return this.iConexion.Motos!.Include(x => x._Modelos).Include(x => x._Marcas).ToList();
            }

            public Motos Guardar(Motos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Motos",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó la moto con id {entidad.Id}",
                UsuariosId = 1
            });
            this.iConexion.Motos!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public Motos Modificar(Motos entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Motos",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la moto con id {entidad.Id}",
                UsuariosId = 1
            });

            var entry = this.iConexion!.Entry<Motos>(entidad);
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
                Entidad = "Motos",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la moto con id {id}",
                UsuariosId = 1
            });
            var entidad = new Motos();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<Motos>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }

