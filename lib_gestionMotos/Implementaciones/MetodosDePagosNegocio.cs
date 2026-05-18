

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class MetodosDePagosNegocio : IMetodosDePagosNegocio
    {
    
            private IConexion? iConexion;
            public List<MetodosDePagos> Consultar()
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Metodos de pagos",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron los métodos de pago",
                UsuariosId = 1
            });
            return this.iConexion.MetodosDePagos!.ToList();
            }

            public MetodosDePagos Guardar(MetodosDePagos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Metodos de pagos",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó el método de pago con id {entidad.Id}",
                UsuariosId = 1
            });
            this.iConexion.MetodosDePagos!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public MetodosDePagos Modificar(MetodosDePagos entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Metodos de pagos",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó el método de pago con id {entidad.Id}",
                UsuariosId = 1
            });

            var entry = this.iConexion!.Entry<MetodosDePagos>(entidad);
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
                Entidad = "Metodos de pagos",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró el método de pago con id {id}",
                UsuariosId = 1
            });
            var entidad = new MetodosDePagos();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<MetodosDePagos>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }

