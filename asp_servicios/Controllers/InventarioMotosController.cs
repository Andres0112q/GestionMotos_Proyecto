using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventarioMotosController : ControllerBase
    {
        private IInventarioMotosNegocio? IInventarioMotosNegocio;

        public InventarioMotosController()
        {
            this.IInventarioMotosNegocio = new InventarioMotosNegocio();
        }

        [HttpGet]
        public List<InventarioMotos> Consultar()
        {
            if (this.IInventarioMotosNegocio == null)
                throw new Exception("No implementado");
            return this.IInventarioMotosNegocio!.Consultar();
        }

        [HttpPost]
        public InventarioMotos Guardar(InventarioMotos entidad)
        {
            if (this.IInventarioMotosNegocio == null)
                throw new Exception("No implementado");
            return this.IInventarioMotosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public InventarioMotos Modificar(InventarioMotos entidad)
        {
            if (this.IInventarioMotosNegocio == null)
                throw new Exception("No implementado");
            return this.IInventarioMotosNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IInventarioMotosNegocio == null)
                throw new Exception("No implementado");
            return IInventarioMotosNegocio!.Borrar(id);
        }

    }
}
