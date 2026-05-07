using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpleadosController : ControllerBase
    {
        private IEmpleadosNegocio? IEmpleadosNegocio;

        public EmpleadosController()
        {
            this.IEmpleadosNegocio = new EmpleadosNegocio();
        }

        [HttpGet]
        public List<Empleados> Consultar()
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Consultar();
        }

        [HttpPost]
        public Empleados Guardar(Empleados entidad)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Empleados Modificar(Empleados entidad)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return IEmpleadosNegocio!.Borrar(id);
        }

    }
}
