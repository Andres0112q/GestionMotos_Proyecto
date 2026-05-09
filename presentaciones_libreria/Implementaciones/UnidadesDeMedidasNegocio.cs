using lib_gestionMotos.Entidades;
using Newtonsoft.Json;
using presentaciones_libreria.Interfaces;

namespace presentaciones_libreria.Implementaciones
{
    public class UnidadesDeMedidasNegocio : IUnidadesDeMedidasNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<UnidadesDeMedidas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/UnidadesDeMedidas/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<UnidadesDeMedidas>();

            return JsonConvert.DeserializeObject<List<UnidadesDeMedidas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public UnidadesDeMedidas Guardar(UnidadesDeMedidas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/UnidadesDeMedidas/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new UnidadesDeMedidas();

            return JsonConvert.DeserializeObject<UnidadesDeMedidas>(
                respuesta["Valor"].ToString()!)!;
        }

        public UnidadesDeMedidas Modificar(UnidadesDeMedidas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/UnidadesDeMedidas/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new UnidadesDeMedidas();

            return JsonConvert.DeserializeObject<UnidadesDeMedidas>(
                respuesta["Valor"].ToString()!)!;
        }
        public UnidadesDeMedidas Borrar(UnidadesDeMedidas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5203/UnidadesDeMedidas/Borrar/{entidad.Id}";
            datos["Metodo"] = "DELETE";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new UnidadesDeMedidas();

            return JsonConvert.DeserializeObject<UnidadesDeMedidas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
