using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetodosDePagosController : ControllerBase
    {
        private IMetodosDePagosNegocio? IMetodosDePagosNegocio;

        public MetodosDePagosController()
        {
            this.IMetodosDePagosNegocio = new MetodosDePagosNegocio();
        }

        [HttpGet]
        public List<MetodosDePagos> Consultar()
        {
            if (this.IMetodosDePagosNegocio == null)
                throw new Exception("No implementado");
            return this.IMetodosDePagosNegocio!.Consultar();
        }

        [HttpPost]
        public MetodosDePagos Guardar(MetodosDePagos entidad)
        {
            if (this.IMetodosDePagosNegocio == null)
                throw new Exception("No implementado");
            return this.IMetodosDePagosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public MetodosDePagos Modificar(MetodosDePagos entidad)
        {
            if (this.IMetodosDePagosNegocio == null)
                throw new Exception("No implementado");
            return this.IMetodosDePagosNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IMetodosDePagosNegocio == null)
                throw new Exception("No implementado");
            return IMetodosDePagosNegocio!.Borrar(id);
        }

    }
}
