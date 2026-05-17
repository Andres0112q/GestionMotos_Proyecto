using lib_gestionMotos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_libreria.Implementaciones;
using presentaciones_libreria.Interfaces;

namespace presentacionmotos_aspnetcore.Pages
{
    public class MotosModel : PageModel
    {
        private IMotosNegocio? iMotosNegocio;
        private IModelosNegocio? iModelosNegocio;
        private IMarcasNegocio? iMarcasNegocio;
        [BindProperty] public List<Motos>? Lista { get; set; }
        [BindProperty] public Motos? Moto { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Modelos>? ListaModelos { get; set; }
        [BindProperty] public List<Marcas>? ListaMarcas { get; set; }

        private void CargarModelos()
        {
            ListaModelos = iModelosNegocio!.Consultar();
        }
        private void CargarMarcas()
        {
            ListaMarcas = iMarcasNegocio!.Consultar();
        }

        public MotosModel()
        {
            iMotosNegocio = new MotosNegocio();
            iModelosNegocio = new ModelosNegocio();
            iMarcasNegocio = new MarcasNegocio();
            CargarModelos();
            CargarMarcas();
        }

        public void OnGet()
        {
            CargarModelos();
            CargarMarcas();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (iMotosNegocio == null)
                    return;
                CargarModelos();
                CargarMarcas();
                Lista = iMotosNegocio.Consultar();
                Moto = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            CargarModelos();
            CargarMarcas();
            Moto = new Motos();
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                CargarModelos();
                CargarMarcas();
                OnPostBtRefrescar();
                Moto = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Moto == null)
                    return;
                if (Moto.Id == 0)
                    Moto = iMotosNegocio!.Guardar(Moto!);
                else
                    Moto = iMotosNegocio!.Modificar(Moto!);
                if (Moto.Id == 0)
                    return;
                CargarModelos();
                CargarMarcas();
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
                if (Moto == null)
                    return;
                iMotosNegocio!.Borrar(Moto!);
                CargarModelos();
                CargarMarcas();
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
                CargarModelos();
                CargarMarcas();
                Moto = Lista!.FirstOrDefault(x => x.Id == data);
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
            CargarModelos();
            CargarMarcas();
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
