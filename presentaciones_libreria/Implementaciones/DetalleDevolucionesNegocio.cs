


using lib_gestionMotos.Entidades;
using Newtonsoft.Json;
using presentaciones_libreria.Interfaces;

namespace presentaciones_libreria.Implementaciones
{
    public class DetalleDevolucionesNegocio : IDetalleDevolucionesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<DetalleDevoluciones> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/DetalleDevoluciones/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<DetalleDevoluciones>();

            return JsonConvert.DeserializeObject<List<DetalleDevoluciones>>(
                respuesta["Valor"].ToString()!)!;
        }

        public DetalleDevoluciones Guardar(DetalleDevoluciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/DetalleDevoluciones/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new DetalleDevoluciones();

            return JsonConvert.DeserializeObject<DetalleDevoluciones>(
                respuesta["Valor"].ToString()!)!;
        }

        public DetalleDevoluciones Modificar(DetalleDevoluciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/DetalleDevoluciones/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new DetalleDevoluciones();

            return JsonConvert.DeserializeObject<DetalleDevoluciones>(
                respuesta["Valor"].ToString()!)!;
        }
        public DetalleDevoluciones Borrar(DetalleDevoluciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5203/DetalleDevoluciones/Borrar/{entidad.Id}";
            datos["Metodo"] = "DELETE";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new DetalleDevoluciones();

            return JsonConvert.DeserializeObject<DetalleDevoluciones>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
