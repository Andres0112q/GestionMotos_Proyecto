using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrdenComprasController : ControllerBase
    {
        private IOrdenComprasNegocio? IOrdenComprasNegocio;

        public OrdenComprasController()
        {
            this.IOrdenComprasNegocio = new OrdenComprasNegocio();
        }

        [HttpGet]
        public List<OrdenCompras> Consultar()
        {
            if (this.IOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IOrdenComprasNegocio!.Consultar();
        }

        [HttpPost]
        public OrdenCompras Guardar(OrdenCompras entidad)
        {
            if (this.IOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IOrdenComprasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public OrdenCompras Modificar(OrdenCompras entidad)
        {
            if (this.IOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return this.IOrdenComprasNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IOrdenComprasNegocio == null)
                throw new Exception("No implementado");
            return IOrdenComprasNegocio!.Borrar(id);
        }

    }
}
