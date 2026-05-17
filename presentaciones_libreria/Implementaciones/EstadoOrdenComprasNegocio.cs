using lib_gestionMotos.Entidades;
using Newtonsoft.Json;
using presentaciones_libreria.Interfaces;

namespace presentaciones_libreria.Implementaciones
{
    public class EstadoOrdenComprasNegocio : IEstadoOrdenComprasNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<EstadoOrdenCompras> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/EstadoOrdenCompras/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<EstadoOrdenCompras>();

            return JsonConvert.DeserializeObject<List<EstadoOrdenCompras>>(
                respuesta["Valor"].ToString()!)!;
        }

        public EstadoOrdenCompras Guardar(EstadoOrdenCompras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/EstadoOrdenCompras/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new EstadoOrdenCompras();

            return JsonConvert.DeserializeObject<EstadoOrdenCompras>(
                respuesta["Valor"].ToString()!)!;
        }

        public EstadoOrdenCompras Modificar(EstadoOrdenCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/EstadoOrdenCompras/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new EstadoOrdenCompras();

            return JsonConvert.DeserializeObject<EstadoOrdenCompras>(
                respuesta["Valor"].ToString()!)!;
        }
        public bool Borrar(EstadoOrdenCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5203/EstadoOrdenCompras/Borrar/{entidad.Id}";
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
