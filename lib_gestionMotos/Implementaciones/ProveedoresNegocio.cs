

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class ProveedoresNegocio : IProveedoresNegocio
    {
            private IConexion? iConexion;
            public List<Proveedores> Consultar()
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Proveedores",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los proveedores",
                UsuariosId = 1
            });

            return this.iConexion.Proveedores!.ToList();
            }

            public Proveedores Guardar(Proveedores entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Proveedores",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el proveedor con id {entidad.Id}",
                UsuariosId = 1
            });

            this.iConexion.Proveedores!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public Proveedores Modificar(Proveedores entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Proveedores",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el proveedor con id {entidad.Id}",
                UsuariosId = 1
            });


            var entry = this.iConexion!.Entry<Proveedores>(entidad);
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
                Entidad = "Proveedores",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el proveedor con id {id}",
                UsuariosId = 1
            });

            var entidad = new Proveedores();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<Proveedores>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }

