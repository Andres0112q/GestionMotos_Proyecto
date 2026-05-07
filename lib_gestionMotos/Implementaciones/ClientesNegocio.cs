using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using lib_gestionMotos.Nucleo;
using Microsoft.EntityFrameworkCore;


namespace lib_gestionMotos.Implementaciones
{
    //clase que implementa la interfaz de clientes negocio,
    //esta clase se encarga de realizar las operaciones CRUD (Crear, Leer, Actualizar, Eliminar)
    //para la entidad Clientes utilizando Entity Framework Core para interactuar con la base de datos.
    public class ClientesNegocio : IClientesNegocio
    {
        private IConexion? iConexion;
        public List<Clientes> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            return this.iConexion.Clientes!.ToList();
        }

        public Clientes Guardar(Clientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            this.iConexion.Clientes!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Clientes Modificar(Clientes entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");


            var entry = this.iConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return entidad;
        }

        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");

            var entidad = new Clientes();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }


    }


}

