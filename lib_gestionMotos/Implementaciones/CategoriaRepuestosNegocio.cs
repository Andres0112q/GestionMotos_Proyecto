

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class CategoriaRepuestosNegocio : ICategoriaRepuestosNegocio
    {
            private IConexion? iConexion;
            public List<CategoriaRepuestos> Consultar()
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                return this.iConexion.CategoriaRepuestos!.ToList();
            }

            public CategoriaRepuestos Guardar(CategoriaRepuestos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                this.iConexion.CategoriaRepuestos!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public CategoriaRepuestos Modificar(CategoriaRepuestos entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("No se puede modificar una entidad que no ha sido guardada");
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


                var entry = this.iConexion!.Entry<CategoriaRepuestos>(entidad);
                entry.State = EntityState.Modified;
                this.iConexion!.SaveChanges();

                return entidad;
            }

            public bool Borrar(int id)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                var entidad = new CategoriaRepuestos();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<CategoriaRepuestos>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }
