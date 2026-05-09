using lib_gestionMotos.Entidades;
using Newtonsoft.Json;
using presentaciones_libreria.Interfaces;

namespace presentaciones_libreria.Implementaciones
{
    public class CategoriaRepuestosNegocio : ICategoriaRepuestosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<CategoriaRepuestos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/CategoriaRepuestos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<CategoriaRepuestos>();

            return JsonConvert.DeserializeObject<List<CategoriaRepuestos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public CategoriaRepuestos Guardar(CategoriaRepuestos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/CategoriaRepuestos/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new CategoriaRepuestos();

            return JsonConvert.DeserializeObject<CategoriaRepuestos>(
                respuesta["Valor"].ToString()!)!;
        }

        public CategoriaRepuestos Modificar(CategoriaRepuestos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5203/CategoriaRepuestos/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new CategoriaRepuestos();

            return JsonConvert.DeserializeObject<CategoriaRepuestos>(
                respuesta["Valor"].ToString()!)!;
        }
        public CategoriaRepuestos Borrar(CategoriaRepuestos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5203/CategoriaRepuestos/Borrar/{entidad.Id}";
            datos["Metodo"] = "DELETE";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new CategoriaRepuestos();

            return JsonConvert.DeserializeObject<CategoriaRepuestos>(
                respuesta["Valor"].ToString()!)!;
        }

    }
}
