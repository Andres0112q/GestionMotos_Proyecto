using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstadoOrdenComprasController : ControllerBase
    {
        private IEstadoOrdenComprasNegocio? IEstadoOrdenComprasNegocio;

        public EstadoOrdenComprasController()
        {
            this.IEstadoOrdenComprasNegocio = new EstadoOrdenComprasNegocio();
        }

        [HttpGet]
        public List<EstadoOrdenCompras> Consultar()
        {
            if (this.IEstadoOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoOrdenComprasNegocio!.Consultar();
        }

        [HttpPost]
        public EstadoOrdenCompras Guardar(EstadoOrdenCompras entidad)
        {
            if (this.IEstadoOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoOrdenComprasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public EstadoOrdenCompras Modificar(EstadoOrdenCompras entidad)
        {
            if (this.IEstadoOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoOrdenComprasNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IEstadoOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return IEstadoOrdenComprasNegocio!.Borrar(id);
        }

    }
}
