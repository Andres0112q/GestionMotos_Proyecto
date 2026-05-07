using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ModelosController : ControllerBase
    {
        private IModelosNegocio? IModelosNegocio;

        public ModelosController()
        {
            this.IModelosNegocio = new ModelosNegocio();
        }

        [HttpGet]
        public List<Modelos> Consultar()
        {
            if (this.IModelosNegocio == null)
                throw new Exception("No implementado");
            return this.IModelosNegocio!.Consultar();
        }

        [HttpPost]
        public Modelos Guardar (Modelos entidad)
        {
            if(this.IModelosNegocio == null)
                throw new Exception("No implementado");
            return this.IModelosNegocio!.Guardar(entidad);
        }


        [HttpPut]
        public Modelos Modificar (Modelos entidad)
        {
            if (this.IModelosNegocio == null)
                throw new Exception("No implementado");
            return this.IModelosNegocio!.Modificar(entidad); 
        }


        [HttpDelete ("{id}")]
        public bool Borrar (int id)
        {
            if(this.IModelosNegocio == null)
                throw new Exception("No implementado");
            return this.IModelosNegocio!.Borrar(id);

        }

    }




}
