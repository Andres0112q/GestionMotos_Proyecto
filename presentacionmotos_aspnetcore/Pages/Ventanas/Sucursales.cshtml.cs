using lib_gestionMotos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_libreria.Implementaciones;
using presentaciones_libreria.Interfaces;

namespace presentacionmotos_aspnetcore.Pages
{
    public class SucursalesModel : PageModel
    {
        private ISucursalesNegocio? iSucursalesNegocio;
        private IMotosNegocio? iMotosNegocio;
        private IModelosNegocio? iModelosNegocio;
        [BindProperty] public string? Departamento { get; set; }
        public List<Sucursales>? ListaSucursales { get; set; }
        public List<Motos>? ListaMotos { get; set; }
        public List<Modelos>? ListaModelos { get; set; }
        public void OnGet()
        {

        }
        private void CargarModelos()
        {
            ListaModelos = iModelosNegocio!.Consultar();
        }
        private void CargarMotos()
        {
            ListaMotos = iMotosNegocio!.Consultar();
        }
        public SucursalesModel()
        {
            iMotosNegocio = new MotosNegocio();
            iSucursalesNegocio = new SucursalesNegocio();
            iModelosNegocio = new ModelosNegocio();
            CargarMotos();
            CargarModelos();
        }
        public void OnPostBtPorDepartamento()
        {
            CargarMotos();
            CargarModelos();
            ListaSucursales = iSucursalesNegocio!.PorDepartamento(Departamento!);
        }
    }
}
