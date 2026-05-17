
using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class GarantiasNegocio : IGarantiasNegocio
    {
        private IConexion? iConexion;
        public List<Garantias> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Garantias",
                Accion = "Consultar",
                Fecha = DateTime.Now,
                Descripcion = "Se consultaron las garantias"
            });

            return this.iConexion.Garantias!.ToList();
        }

        public Garantias Guardar(Garantias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Garantias",
                Accion = "Guardar",
                Fecha = DateTime.Now,
                Descripcion = $"Se guardó la garantia con id {entidad.Id}"
            });
            this.iConexion.Garantias!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Garantias Modificar(Garantias entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Entidad = "Garantias",
                Accion = "Modificar",
                Fecha = DateTime.Now,
                Descripcion = $"Se modificó la garantia con id {entidad.Id}"
            });

            var entry = this.iConexion!.Entry<Garantias>(entidad);
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
                Entidad = "Garantias",
                Accion = "Borrar",
                Fecha = DateTime.Now,
                Descripcion = $"Se borró la garantia con id {id}"
            });

            var entidad = new Garantias();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<Garantias>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }

        public Garantias ActualizacionDescripcion(Garantias entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            if(entidad.FechaVencimiento.Date <= DateTime.Now.Date) //Si la fecha de vencimiento es menor o igual a la fecha actual, la garantía está vencida
            {
                entidad.Activo = false;
                entidad.DescripcionEstado = "Garantia Vencida";

            }
            else if(entidad.FechaVencimiento.Date > DateTime.Now.Date &&
                entidad.FechaVencimiento.Date <= DateTime.Now.Date.AddDays(7))//Si la fecha de vencimiento es mayor a la fecha actual y menor o igual a 7 días, la garantía está próxima a vencer
            {
                entidad.Activo = true;
                entidad.DescripcionEstado = "Garantia Próxima a Vencer";
            }
            else // Si no cumple ninguna de las dos condiciones de arriba, la garantía está activa y lejos de vencerse
            {
                entidad.Activo = true;
                entidad.DescripcionEstado = "Garantia Activa";
            }
            var entry = this.iConexion!.Entry<Garantias>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return entidad;
        }
    }
}
