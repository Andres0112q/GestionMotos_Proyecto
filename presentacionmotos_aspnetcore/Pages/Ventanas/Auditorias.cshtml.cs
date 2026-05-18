using lib_gestionMotos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_libreria.Implementaciones;
using presentaciones_libreria.Interfaces;


namespace presentacionmotos_aspnetcore.Pages
{
    public class AuditoriasModel : PageModel
    {
        private IAuditoriasNegocio? iAuditoriasNegocio;
        [BindProperty] public List<Auditorias>? Lista { get; set; }
        [BindProperty] public Auditorias? Venta { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public AuditoriasModel()
        {
            iAuditoriasNegocio = new AuditoriasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

      
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iAuditoriasNegocio == null)
                    return;
                Lista = iAuditoriasNegocio.Consultar();
                Venta = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Venta = new Auditorias();
            Borrando = false;
        }

       
        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Venta = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
