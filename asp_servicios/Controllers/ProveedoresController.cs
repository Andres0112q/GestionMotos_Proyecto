using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class ProveedoresController : ControllerBase
    {
        private IProveedoresNegocio? IProveedoresNegocio;

        public ProveedoresController()
        {
            this.IProveedoresNegocio = new ProveedoresNegocio();
        }

        [HttpGet]
        public List<Proveedores> Consultar()
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Consultar();
        }

        [HttpPost]
        public Proveedores Guardar (Proveedores entidad)
        {
            if(this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Guardar(entidad);
        }


        [HttpPut]
        public Proveedores Modificar (Proveedores entidad)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Modificar(entidad); 
        }


        [HttpDelete ("{id}")]
        public bool Borrar (int id)
        {
            if(this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Borrar(id);

        }

    }




}
