using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DevolucionProveedoresController : ControllerBase
    {
        private IDevolucionProveedoresNegocio? IDevolucionProveedoresNegocio;

        public DevolucionProveedoresController()
        {
            this.IDevolucionProveedoresNegocio = new DevolucionProveedoresNegocio();
        }

        [HttpGet]
        public List<DevolucionProveedores> Consultar()
        {
            if (this.IDevolucionProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IDevolucionProveedoresNegocio!.Consultar();
        }

        [HttpPost]
        public DevolucionProveedores Guardar(DevolucionProveedores entidad)
        {
            if (this.IDevolucionProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IDevolucionProveedoresNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public DevolucionProveedores Modificar(DevolucionProveedores entidad)
        {
            if (this.IDevolucionProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IDevolucionProveedoresNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IDevolucionProveedoresNegocio == null)
                throw new Exception("No implementado");
            return IDevolucionProveedoresNegocio!.Borrar(id);
        }

    }
}
