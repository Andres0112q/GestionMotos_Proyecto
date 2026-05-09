using lib_gestionMotos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_libreria.Implementaciones;
using presentaciones_libreria.Interfaces;

namespace presentacionmotos_aspnetcore.Pages
{
    public class MarcasModel : PageModel
    {
        private IMarcasNegocio? iMarcasNegocio;
        [BindProperty] public List<Marcas>? Lista { get; set; }
        [BindProperty] public Marcas? Marca { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public MarcasModel()
        {
            iMarcasNegocio = new MarcasNegocio();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try
            {
                if (iMarcasNegocio == null) return;
                Lista = iMarcasNegocio.Consultar();
                Marca = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Marca = new Marcas();
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Marca = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Marca == null) return;
                if (Marca.Id == 0)
                    Marca = iMarcasNegocio!.Guardar(Marca!);
                else
                    Marca = iMarcasNegocio!.Modificar(Marca!);
                if (Marca.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Marca == null) return;
                Marca = iMarcasNegocio!.Borrar(Marca!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Marca = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}