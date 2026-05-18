
using lib_gestionMotos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_libreria.Implementaciones;
using presentaciones_libreria.Interfaces;

namespace presentacionmotos_aspnetcore.Pages
{
    public class MetodosDePagosModel : PageModel
    {
        private IMetodosDePagosNegocio? iMetodosDePagosNegocio;
        [BindProperty] public List<MetodosDePagos>? Lista { get; set; }
        [BindProperty] public MetodosDePagos? MetodosDePago { get; set; }
        [BindProperty] public bool Borrando { get; set; }



        public MetodosDePagosModel()
        {
            iMetodosDePagosNegocio = new MetodosDePagosNegocio();

        }

        public void OnGet()
        {

            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (iMetodosDePagosNegocio == null)
                    return;

                Lista = iMetodosDePagosNegocio.Consultar();
                MetodosDePago = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {

            MetodosDePago = new MetodosDePagos();
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {

                OnPostBtRefrescar();
                MetodosDePago = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (MetodosDePago == null)
                    return;
                if (MetodosDePago.Id == 0)
                    MetodosDePago = iMetodosDePagosNegocio!.Guardar(MetodosDePago!);
                else
                    MetodosDePago = iMetodosDePagosNegocio!.Modificar(MetodosDePago!);
                if (MetodosDePago.Id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (MetodosDePago == null)
                    return;
                iMetodosDePagosNegocio!.Borrar(MetodosDePago!);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                MetodosDePago = Lista!.FirstOrDefault(x => x.Id == data);
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
