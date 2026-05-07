using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetalleOrdenComprasController : ControllerBase
    {
        private IDetalleOrdenComprasNegocio? IDetalleOrdenComprasNegocio;

        public DetalleOrdenComprasController()
        {
            this.IDetalleOrdenComprasNegocio = new DetalleOrdenComprasNegocio();
        }

        [HttpGet]
        public List<DetalleOrdenCompras> Consultar()
        {
            if (this.IDetalleOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IDetalleOrdenComprasNegocio!.Consultar();
        }

        [HttpPost]
        public DetalleOrdenCompras Guardar(DetalleOrdenCompras entidad)
        {
            if (this.IDetalleOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IDetalleOrdenComprasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public DetalleOrdenCompras Modificar(DetalleOrdenCompras entidad)
        {
            if (this.IDetalleOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IDetalleOrdenComprasNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IDetalleOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return IDetalleOrdenComprasNegocio!.Borrar(id);
        }

    }
}
