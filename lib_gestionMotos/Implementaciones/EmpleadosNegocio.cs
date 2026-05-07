

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
        public class EmpleadosNegocio : IEmpleadosNegocio
        {
            private IConexion? iConexion;
            public List<Empleados> Consultar()
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                return this.iConexion.Empleados!.ToList();
            }

            public Empleados Guardar(Empleados entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                this.iConexion.Empleados!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public Empleados Modificar(Empleados entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


                var entry = this.iConexion!.Entry<Empleados>(entidad);
                entry.State = EntityState.Modified;
                this.iConexion!.SaveChanges();

                return entidad;
            }

            public bool Borrar(int id)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                var entidad = new Empleados();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<Empleados>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }



