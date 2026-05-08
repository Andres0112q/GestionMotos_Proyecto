using lib_gestionMotos.Entidades;
using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControllerBase
    {
        private IAuditoriasNegocio? IAuditoriasNegocio;

        public AuditoriasController()
        {
            this.IAuditoriasNegocio = new AuditoriasNegocio();
        }

        [HttpGet]
        public List<Auditorias> Consultar()
        {
            if (this.IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return this.IAuditoriasNegocio!.Consultar();
        }

        [HttpPost]
        public Auditorias Guardar(Auditorias entidad)
        {
            if (this.IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return this.IAuditoriasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Auditorias Modificar(Auditorias entidad)
        {
            if (this.IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return this.IAuditoriasNegocio!.Modificar(entidad);
        }

        [HttpDelete ("{id}")]
        public bool Borrar(int id)
        {
            if(this.IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return IAuditoriasNegocio!.Borrar(id);
        }

    }
}
