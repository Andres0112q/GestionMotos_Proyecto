using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovimientosInventariosController : ControllerBase
    {
        private IMovimientosInventariosNegocio? IMovimientosInventariosNegocio;

        public MovimientosInventariosController()
        {
            this.IMovimientosInventariosNegocio = new MovimientosInventariosNegocio();
        }

        [HttpGet]
        public List<MovimientosInventarios> Consultar()
        {
            if (this.IMovimientosInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.IMovimientosInventariosNegocio!.Consultar();
        }

        [HttpPost]
        public MovimientosInventarios Guardar(MovimientosInventarios entidad)
        {
            if (this.IMovimientosInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.IMovimientosInventariosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public MovimientosInventarios Modificar(MovimientosInventarios entidad)
        {
            if (this.IMovimientosInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.IMovimientosInventariosNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IMovimientosInventariosNegocio == null)
                throw new Exception("No implementado");
            return IMovimientosInventariosNegocio!.Borrar(id);
        }

    }
}
