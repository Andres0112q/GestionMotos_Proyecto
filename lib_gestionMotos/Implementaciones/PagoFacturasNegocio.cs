

using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class PagoFacturasNegocio : IPagoFacturasNegocio
    {
        private IConexion? iConexion;
        public List<PagoFacturas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            return this.iConexion.PagoFacturas!.Include(x => x._Facturas).Include(x => x._MetodosDePagos).ToList();
        }

        public PagoFacturas Guardar(PagoFacturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.PagoFacturas!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public PagoFacturas Modificar(PagoFacturas entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


            var entry = this.iConexion!.Entry<PagoFacturas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return entidad;
        }

        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = new PagoFacturas();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<PagoFacturas>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }


    }
}
