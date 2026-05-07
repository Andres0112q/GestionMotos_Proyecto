using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StockRepuestosController : ControllerBase
    {
        private IStockRepuestosNegocio? IStockRepuestosNegocio;

        public StockRepuestosController()
        {
            this.IStockRepuestosNegocio = new StockRepuestosNegocio();
        }

        [HttpGet]
        public List<StockRepuestos> Consultar()
        {
            if (this.IStockRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.IStockRepuestosNegocio!.Consultar();
        }

        [HttpPost]
        public StockRepuestos Guardar(StockRepuestos entidad)
        {
            if (this.IStockRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.IStockRepuestosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public StockRepuestos Modificar(StockRepuestos entidad)
        {
            if (this.IStockRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.IStockRepuestosNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IStockRepuestosNegocio == null)
                throw new Exception("No implementado");
            return IStockRepuestosNegocio!.Borrar(id);
        }

    }
}
