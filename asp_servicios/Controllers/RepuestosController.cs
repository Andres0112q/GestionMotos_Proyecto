using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RepuestosController : ControllerBase
    {
        private IRepuestosNegocio? IRepuestosNegocio;

        public RepuestosController()
        {
            this.IRepuestosNegocio = new RepuestosNegocio();
        }

        [HttpGet]
        public List<Repuestos> Consultar()
        {
            if (this.IRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.IRepuestosNegocio!.Consultar();
        }

        [HttpPost]
        public Repuestos Guardar(Repuestos entidad)
        {
            if (this.IRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.IRepuestosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Repuestos Modificar(Repuestos entidad)
        {
            if (this.IRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.IRepuestosNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IRepuestosNegocio == null)
                throw new Exception("No implementado");
            return IRepuestosNegocio!.Borrar(id);
        }

    }
}
