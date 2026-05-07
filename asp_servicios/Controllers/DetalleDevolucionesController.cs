using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetalleDevolucionesController : ControllerBase
    {
        private IDetalleDevolucionesNegocio? IDetalleDevolucionesNegocio;

        public DetalleDevolucionesController()
        {
            this.IDetalleDevolucionesNegocio = new DetalleDevolucionesNegocio();
        }

        [HttpGet]
        public List<DetalleDevoluciones> Consultar()
        {
            if (this.IDetalleDevolucionesNegocio == null)
                throw new Exception("No implementado");
            return this.IDetalleDevolucionesNegocio!.Consultar();
        }

        [HttpPost]
        public DetalleDevoluciones Guardar(DetalleDevoluciones entidad)
        {
            if (this.IDetalleDevolucionesNegocio == null)
                throw new Exception("No implementado");
            return this.IDetalleDevolucionesNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public DetalleDevoluciones Modificar(DetalleDevoluciones entidad)
        {
            if (this.IDetalleDevolucionesNegocio == null)
                throw new Exception("No implementado");
            return this.IDetalleDevolucionesNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IDetalleDevolucionesNegocio == null)
                throw new Exception("No implementado");
            return IDetalleDevolucionesNegocio!.Borrar(id);
        }

    }
}
