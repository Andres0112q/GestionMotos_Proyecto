
using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class FacturasNegocio : IFacturasNegocio
    {
        private IConexion? iConexion;
        public List<Facturas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Facturas",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las facturas"
            });

            return this.iConexion.Facturas!.ToList();
        }

        public Facturas Guardar(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Facturas",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó la factura con id {entidad.Id}"
            });

            this.iConexion.Facturas!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Facturas Modificar(Facturas entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Facturas",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la factura con id {entidad.Id}"
            });


            var entry = this.iConexion!.Entry<Facturas>(entidad);
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
                Entidad = "Facturas",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la factura con id {id}"
            });
            var entidad = new Facturas();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<Facturas>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
