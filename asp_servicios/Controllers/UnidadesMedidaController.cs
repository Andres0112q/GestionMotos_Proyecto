using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class UnidadesDeMedidasController : ControllerBase
    {
        private IUnidadesDeMedidasNegocio? IUnidadesDeMedidasNegocio;

        public UnidadesDeMedidasController()
        {
            this.IUnidadesDeMedidasNegocio = new UnidadesDeMedidasNegocio();
        }

        [HttpGet]
        public List<UnidadesDeMedidas> Consultar()
        {
            if (this.IUnidadesDeMedidasNegocio == null)
                throw new Exception("No implementado");
            return this.IUnidadesDeMedidasNegocio!.Consultar();
        }

        [HttpPost]
        public UnidadesDeMedidas Guardar(UnidadesDeMedidas entidad)
        {
            if (this.IUnidadesDeMedidasNegocio == null)
                throw new Exception("No implementado");
            return this.IUnidadesDeMedidasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public UnidadesDeMedidas Modificar(UnidadesDeMedidas entidad)
        {
            if (this.IUnidadesDeMedidasNegocio == null)
                throw new Exception("No implementado");
            return this.IUnidadesDeMedidasNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{Id}")]
        public bool Borrar(int id)
        {
            if (this.IUnidadesDeMedidasNegocio == null)
                throw new Exception("No implementado");
            return this.IUnidadesDeMedidasNegocio!.Borrar(id);
        }



    }




}
