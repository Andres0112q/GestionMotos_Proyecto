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
        [BindProperty] public List<Motos>? Lista { get; set; }
        [BindProperty] public Motos? Moto { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public MotosModel()
        {
            iMotosNegocio = new MotosNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (iMotosNegocio == null)
                    return;
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
            Moto = new Motos();
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
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
                Moto = iMotosNegocio!.Borrar(Moto!);
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
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
