

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

                return this.iConexion.Proveedores!.ToList();
            }

            public Proveedores Guardar(Proveedores entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                this.iConexion.Proveedores!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public Proveedores Modificar(Proveedores entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


                var entry = this.iConexion!.Entry<Proveedores>(entidad);
                entry.State = EntityState.Modified;
                this.iConexion!.SaveChanges();

                return entidad;
            }

            public bool Borrar(int id)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                var entidad = new Proveedores();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<Proveedores>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }

