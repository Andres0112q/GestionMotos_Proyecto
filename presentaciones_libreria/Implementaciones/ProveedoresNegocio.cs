using lib_gestionMotos.Entidades;
using Newtonsoft.Json;
using presentaciones_libreria.Interfaces;

namespace presentaciones_libreria.Implementaciones
{
    public class ProveedoresNegocio : IProveedoresNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Proveedores> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/Proveedores/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Proveedores>();

            return JsonConvert.DeserializeObject<List<Proveedores>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Proveedores Guardar(Proveedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/Proveedores/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Proveedores();

            return JsonConvert.DeserializeObject<Proveedores>(
                respuesta["Valor"].ToString()!)!;
        }

        public Proveedores Modificar(Proveedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/Proveedores/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Proveedores();

            return JsonConvert.DeserializeObject<Proveedores>(
                respuesta["Valor"].ToString()!)!;
        }
        public Proveedores Borrar(Proveedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5203/Proveedores/Borrar/{entidad.Id}";
            datos["Metodo"] = "DELETE";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Proveedores();

            return JsonConvert.DeserializeObject<Proveedores>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
