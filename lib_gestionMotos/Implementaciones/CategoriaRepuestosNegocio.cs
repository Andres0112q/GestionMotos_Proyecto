

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
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Categoria Repuestos",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las categorias de repuestos"
            });

            return this.iConexion.CategoriaRepuestos!.ToList();
            }

            public CategoriaRepuestos Guardar(CategoriaRepuestos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Categoria Repuestos",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardo la categoria de repuestos con nombre {entidad.Nombre}"
            });


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
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Categoria Repuestos",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la categoria de repuestos con id {entidad.Id}"
            });



            var entry = this.iConexion!.Entry<CategoriaRepuestos>(entidad);
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
                Entidad = "Categoria Repuestos",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la categoria de repuestos con id {id}"
            });


            var entidad = new CategoriaRepuestos();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<CategoriaRepuestos>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }
