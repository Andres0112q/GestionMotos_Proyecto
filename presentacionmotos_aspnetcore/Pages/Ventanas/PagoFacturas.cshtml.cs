
using lib_gestionMotos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_libreria.Implementaciones;
using presentaciones_libreria.Interfaces;

namespace presentacionmotos_aspnetcore.Pages
{
    public class PagoFacturasModel : PageModel
    {
        private IPagoFacturasNegocio? iPagoFacturasNegocio;
        private IFacturasNegocio? iFacturasNegocio;
        private IMetodosDePagosNegocio? iMetodosDePagosNegocio;
        [BindProperty] public List<PagoFacturas>? Lista { get; set; }
        [BindProperty] public PagoFacturas? PagoFactura { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Facturas>? ListaFacturas { get; set; }
        [BindProperty] public List<MetodosDePagos>? ListaMetodosDePagos { get; set; }

        private void CargarFacturas()
        {
            ListaFacturas = iFacturasNegocio!.Consultar();
        }
        private void CargarMetodosDePagos()
        {
            ListaMetodosDePagos = iMetodosDePagosNegocio!.Consultar();
        }

        public PagoFacturasModel()
        {
            iPagoFacturasNegocio = new PagoFacturasNegocio();
            iFacturasNegocio = new FacturasNegocio();
            iMetodosDePagosNegocio = new MetodosDePagosNegocio();
            CargarFacturas();
            CargarMetodosDePagos();
        }

        public void OnGet()
        {
            CargarFacturas();
            CargarMetodosDePagos();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (iPagoFacturasNegocio == null)
                    return;
                CargarFacturas();
                CargarMetodosDePagos();
                Lista = iPagoFacturasNegocio.Consultar();
                PagoFactura = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            CargarFacturas();
            CargarMetodosDePagos();
            PagoFactura = new PagoFacturas();
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                CargarFacturas();
                CargarMetodosDePagos();
                OnPostBtRefrescar();
                PagoFactura = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (PagoFactura == null)
                    return;
                if (PagoFactura.Id == 0)
                    PagoFactura = iPagoFacturasNegocio!.Guardar(PagoFactura!);
                else
                    PagoFactura = iPagoFacturasNegocio!.Modificar(PagoFactura!);
                if (PagoFactura.Id == 0)
                    return;
                CargarFacturas();
                CargarMetodosDePagos();
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
                if (PagoFactura == null)
                    return;
                iPagoFacturasNegocio!.Borrar(PagoFactura!);
                CargarFacturas();
                CargarMetodosDePagos();
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
                CargarFacturas();
                CargarMetodosDePagos();
                PagoFactura = Lista!.FirstOrDefault(x => x.Id == data);
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
            CargarFacturas();
            CargarMetodosDePagos();
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
