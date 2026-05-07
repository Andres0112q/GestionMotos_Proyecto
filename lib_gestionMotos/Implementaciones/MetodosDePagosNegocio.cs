

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

                return this.iConexion.MetodosDePagos!.ToList();
            }

            public MetodosDePagos Guardar(MetodosDePagos entidad)
            {
                if (entidad.Id != 0)
                    throw new Exception("Ya se guardo");

                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                this.iConexion.MetodosDePagos!.Add(entidad!);
                this.iConexion.SaveChanges();
                return entidad;
            }
            public MetodosDePagos Modificar(MetodosDePagos entidad)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


                var entry = this.iConexion!.Entry<MetodosDePagos>(entidad);
                entry.State = EntityState.Modified;
                this.iConexion!.SaveChanges();

                return entidad;
            }

            public bool Borrar(int id)
            {
                this.iConexion = new Conexion();
                this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

                var entidad = new MetodosDePagos();
                entidad.Id = id;
                var entry = this.iConexion!.Entry<MetodosDePagos>(entidad);
                entry.State = EntityState.Deleted;
                this.iConexion!.SaveChanges();
                return true;
            }


        }


    }

