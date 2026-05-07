using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriaRepuestosController : ControllerBase
    {
        private ICategoriaRepuestosNegocio? ICategoriaRepuestosNegocio;

        public CategoriaRepuestosController()
        {
            this.ICategoriaRepuestosNegocio = new CategoriaRepuestosNegocio();
        }

        [HttpGet]
        public List<CategoriaRepuestos> Consultar()
        {
            if (this.ICategoriaRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriaRepuestosNegocio!.Consultar();
        }

        [HttpPost]
        public CategoriaRepuestos Guardar(CategoriaRepuestos entidad)
        {
            if (this.ICategoriaRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriaRepuestosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public CategoriaRepuestos Modificar(CategoriaRepuestos entidad)
        {
            if (this.ICategoriaRepuestosNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriaRepuestosNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.ICategoriaRepuestosNegocio == null)
                throw new Exception("No implementado");
            return ICategoriaRepuestosNegocio!.Borrar(id);
        }

    }
}
