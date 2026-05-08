using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GarantiasController : ControllerBase
    {
        private IGarantiasNegocio? IGarantiasNegocio;

        public GarantiasController()
        {
            this.IGarantiasNegocio = new GarantiasNegocio();
        }

        [HttpGet]
        public List<Garantias> Consultar()
        {
            if (this.IGarantiasNegocio == null)
                throw new Exception("No implementado");
            return this.IGarantiasNegocio!.Consultar();
        }

        [HttpPost]
        public Garantias Guardar(Garantias entidad)
        {
            if (this.IGarantiasNegocio == null)
                throw new Exception("No implementado");
            return this.IGarantiasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Garantias Modificar(Garantias entidad)
        {
            if (this.IGarantiasNegocio == null)
                throw new Exception("No implementado");
            return this.IGarantiasNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IGarantiasNegocio == null)
                throw new Exception("No implementado");
            return IGarantiasNegocio!.Borrar(id);
        }

    }
}
