using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacturasController : ControllerBase
    {
        private IFacturasNegocio? IFacturasNegocio;

        public FacturasController()
        {
            this.IFacturasNegocio = new FacturasNegocio();
        }

        [HttpGet]
        public List<Facturas> Consultar()
        {
            if (this.IFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IFacturasNegocio!.Consultar();
        }

        [HttpPost]
        public Facturas Guardar(Facturas entidad)
        {
            if (this.IFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IFacturasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Facturas Modificar(Facturas entidad)
        {
            if (this.IFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IFacturasNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IFacturasNegocio == null)
                throw new Exception("No implementado");
            return IFacturasNegocio!.Borrar(id);
        }

    }
}
