using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SucursalesController : ControllerBase
    {
        private ISucursalesNegocio? ISucursalesNegocio;

        public SucursalesController()
        {
            this.ISucursalesNegocio = new SucursalesNegocio();
        }

        [HttpGet]
        public List<Sucursales> Consultar()
        {
            if (this.ISucursalesNegocio == null)
                throw new Exception("No implementado");
            return this.ISucursalesNegocio!.Consultar();
        }

        [HttpPost]
        public Sucursales Guardar(Sucursales entidad)
        {
            if (this.ISucursalesNegocio == null)
                throw new Exception("No implementado");
            return this.ISucursalesNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Sucursales Modificar(Sucursales entidad)
        {
            if (this.ISucursalesNegocio == null)
                throw new Exception("No implementado");
            return this.ISucursalesNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.ISucursalesNegocio == null)
                throw new Exception("No implementado");
            return ISucursalesNegocio!.Borrar(id);
        }
        [HttpGet("{departamento}")]
        public List<Sucursales> PorDepartamento(string departamento)
        {
            return this.ISucursalesNegocio!.PorDepartamento(departamento);
        }

    }
}
