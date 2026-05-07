using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagoFacturasController : ControllerBase
    {
        private IPagoFacturasNegocio? IPagoFacturasNegocio;

        public PagoFacturasController()
        {
            this.IPagoFacturasNegocio = new PagoFacturasNegocio();
        }

        [HttpGet]
        public List<PagoFacturas> Consultar()
        {
            if (this.IPagoFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IPagoFacturasNegocio!.Consultar();
        }

        [HttpPost]
        public PagoFacturas Guardar(PagoFacturas entidad)
        {
            if (this.IPagoFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IPagoFacturasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public PagoFacturas Modificar(PagoFacturas entidad)
        {
            if (this.IPagoFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IPagoFacturasNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IPagoFacturasNegocio == null)
                throw new Exception("No implementado");
            return IPagoFacturasNegocio!.Borrar(id);
        }

    }
}
