
using lib_gestionMotos.Entidades;
using Newtonsoft.Json;
using presentaciones_libreria.Interfaces;

namespace presentaciones_libreria.Implementaciones
{
    public class DetalleOrdenComprasNegocio : IDetalleOrdenComprasNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<DetalleOrdenCompras> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/DetalleOrdenCompras/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<DetalleOrdenCompras>();

            return JsonConvert.DeserializeObject<List<DetalleOrdenCompras>>(
                respuesta["Valor"].ToString()!)!;
        }

        public DetalleOrdenCompras Guardar(DetalleOrdenCompras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/DetalleOrdenCompras/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new DetalleOrdenCompras();

            return JsonConvert.DeserializeObject<DetalleOrdenCompras>(
                respuesta["Valor"].ToString()!)!;
        }

        public DetalleOrdenCompras Modificar(DetalleOrdenCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/DetalleOrdenCompras/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new DetalleOrdenCompras();

            return JsonConvert.DeserializeObject<DetalleOrdenCompras>(
                respuesta["Valor"].ToString()!)!;
        }
        public bool Borrar(DetalleOrdenCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5203/DetalleOrdenCompras/Borrar/{entidad.Id}";
            datos["Metodo"] = "DELETE";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return false;

            return JsonConvert.DeserializeObject<bool>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
