

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class InventarioMotosNegocio : IInventarioMotosNegocio
    {
        private IConexion? iConexion;
        public List<InventarioMotos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Inventario Motos",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las motos del inventario"
            });

            return this.iConexion.InventarioMotos!.ToList();
        }

        public InventarioMotos Guardar(InventarioMotos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Inventario Motos",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó la moto con id {entidad.Id}"
            });
            this.iConexion.InventarioMotos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public InventarioMotos Modificar(InventarioMotos entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Inventario Motos",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la moto con id {entidad.Id}"
            });

            var entry = this.iConexion!.Entry<InventarioMotos>(entidad);
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
                Entidad = "Inventario Motos",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la moto con id {id}"
            });
            var entidad = new InventarioMotos();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<InventarioMotos>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }

        public InventarioMotos ModificarEstado(InventarioMotos entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            var minimo = 3; //Se define el minimo de unidades para determinar si esta proximo a agotarse
            if (entidad.Cantidad > minimo)
            {
                entidad.Estado = "Disponible";

            }
            else if (entidad.Cantidad > 0 && entidad.Cantidad <= minimo)
            {
                entidad.Estado = "Pocas Unidades";
            }
            else
            {
                entidad.Estado = "Agotado";
            }

            var entry = this.iConexion!.Entry<InventarioMotos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return entidad;


        }

    }
}
