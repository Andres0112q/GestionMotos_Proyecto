

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
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Empleados",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los empleados"
            });

            return this.iConexion.Empleados!.ToList();
            }

            public Empleados Guardar(Empleados entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Empleados",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el empleado con id {entidad.Id}"
            });

            this.iConexion.Empleados!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public Empleados Modificar(Empleados entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Empleados",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el empleado con id {entidad.Id}"
            });


            var entry = this.iConexion!.Entry<Empleados>(entidad);
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
                Entidad = "Empleados",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el empleado con id {id}"
            });

            var entidad = new Empleados();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<Empleados>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }



