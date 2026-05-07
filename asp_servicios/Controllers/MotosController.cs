using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class MotosController : ControllerBase
    {
        private IMotosNegocio? IMotosNegocio;

        public MotosController()
        {
            this.IMotosNegocio = new MotosNegocio();
        }

        [HttpGet]
        public List<Motos> Consultar()
        {
            if (this.IMotosNegocio == null)
                throw new Exception("No implementado");
            return this.IMotosNegocio!.Consultar();
        }

        [HttpPost]
        public Motos Guardar (Motos entidad)
        {
            if(this.IMotosNegocio == null)
                throw new Exception("No implementado");
            return this.IMotosNegocio!.Guardar(entidad);
        }


        [HttpPut]
        public Motos Modificar (Motos entidad)
        {
            if (this.IMotosNegocio == null)
                throw new Exception("No implementado");
            return this.IMotosNegocio!.Modificar(entidad); 
        }


        [HttpDelete ("{id}")]
        public bool Borrar (int id)
        {
            if(this.IMotosNegocio == null)
                throw new Exception("No implementado");
            return this.IMotosNegocio!.Borrar(id);

        }

    }




}
