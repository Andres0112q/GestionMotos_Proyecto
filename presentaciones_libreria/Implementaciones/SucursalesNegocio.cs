
using lib_gestionMotos.Entidades;
using Newtonsoft.Json;
using presentaciones_libreria.Interfaces;

namespace presentaciones_libreria.Implementaciones
{
    public class SucursalesNegocio : ISucursalesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<Sucursales> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/Sucursales/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Sucursales>();

            return JsonConvert.DeserializeObject<List<Sucursales>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Sucursales Guardar(Sucursales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/Sucursales/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Sucursales();

            return JsonConvert.DeserializeObject<Sucursales>(
                respuesta["Valor"].ToString()!)!;
        }

        public Sucursales Modificar(Sucursales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/Sucursales/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Sucursales();

            return JsonConvert.DeserializeObject<Sucursales>(
                respuesta["Valor"].ToString()!)!;
        }
        public Sucursales Borrar(Sucursales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5203/Sucursales/Borrar/{entidad.Id}";
            datos["Metodo"] = "DELETE";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Sucursales();

            return JsonConvert.DeserializeObject<Sucursales>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
