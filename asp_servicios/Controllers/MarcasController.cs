using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class MarcasController : ControllerBase
    {
        private IMarcasNegocio? IMarcasNegocio;

        public MarcasController()
        {
            this.IMarcasNegocio = new MarcasNegocio();
        }

        [HttpGet]
        public List<Marcas> Consultar()
        {
            if (this.IMarcasNegocio == null)
                throw new Exception("No implementado");
            return this.IMarcasNegocio!.Consultar();
        }

        [HttpPost]
        public Marcas Guardar (Marcas entidad)
        {
            if(this.IMarcasNegocio == null)
                throw new Exception("No implementado");
            return this.IMarcasNegocio!.Guardar(entidad);
        }


        [HttpPut]
        public Marcas Modificar (Marcas entidad)
        {
            if (this.IMarcasNegocio == null)
                throw new Exception("No implementado");
            return this.IMarcasNegocio!.Modificar(entidad); 
        }


        [HttpDelete ("{id}")]
        public bool Borrar (int id)
        {
            if(this.IMarcasNegocio == null)
                throw new Exception("No implementado");
            return this.IMarcasNegocio!.Borrar(id);

        }

    }




}
