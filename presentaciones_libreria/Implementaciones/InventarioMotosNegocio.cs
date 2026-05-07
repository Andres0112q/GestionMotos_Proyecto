using lib_gestionMotos.Entidades;
using Newtonsoft.Json;
using presentaciones_libreria.Interfaces;

namespace presentaciones_libreria.Implementaciones
{
    public class InventarioMotosNegocio : IInventarioMotosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<InventarioMotos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/InventarioMotos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<InventarioMotos>();

            return JsonConvert.DeserializeObject<List<InventarioMotos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public InventarioMotos Guardar(InventarioMotos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/InventarioMotos/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new InventarioMotos();

            return JsonConvert.DeserializeObject<InventarioMotos>(
                respuesta["Valor"].ToString()!)!;
        }

        public InventarioMotos Modificar(InventarioMotos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/InventarioMotos/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new InventarioMotos();

            return JsonConvert.DeserializeObject<InventarioMotos>(
                respuesta["Valor"].ToString()!)!;
        }
        public InventarioMotos Borrar(InventarioMotos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5203/InventarioMotos/Borrar/{entidad.Id}";
            datos["Metodo"] = "DELETE";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new InventarioMotos();

            return JsonConvert.DeserializeObject<InventarioMotos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
