
using lib_gestionMotos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_libreria.Implementaciones;
using presentaciones_libreria.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace presentacionmotos_aspnetcore.Pages
{
    public class FacturasModel : PageModel
    {
        private IFacturasNegocio? iFacturasNegocio;
        private IClientesNegocio? iClientesNegocio;
        private IEmpleadosNegocio? iEmpleadosNegocio;
        [BindProperty] public List<Facturas>? Lista { get; set; }
        [BindProperty] public Facturas? Factura { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Clientes>? ListaClientes { get; set; }
        [BindProperty] public List<Empleados>? ListaEmpleados { get; set; }

        private void CargarClientes()
        {
            ListaClientes = iClientesNegocio!.Consultar();
        }
        private void CargarEmpleados()
        {
            ListaEmpleados = iEmpleadosNegocio!.Consultar();
        }

        public FacturasModel()
        {
            iFacturasNegocio = new FacturasNegocio();
            iClientesNegocio = new ClientesNegocio();
            iEmpleadosNegocio = new EmpleadosNegocio();
            CargarClientes();
            CargarEmpleados();
        }

        public void OnGet()
        {
            CargarClientes();
            CargarEmpleados();
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (iFacturasNegocio == null)
                    return;
                CargarClientes();
                CargarEmpleados();
                Lista = iFacturasNegocio.Consultar();
                Factura = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            CargarClientes();
            CargarEmpleados();
            Factura = new Facturas();
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                CargarClientes();
                CargarEmpleados();
                OnPostBtRefrescar();
                Factura = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Factura == null)
                    return;
                if (Factura.Id == 0)
                    Factura = iFacturasNegocio!.Guardar(Factura!);
                else
                    Factura = iFacturasNegocio!.Modificar(Factura!);
                if (Factura.Id == 0)
                    return;
                CargarClientes();
                CargarEmpleados();
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
                if (Factura == null)
                    return;
                iFacturasNegocio!.Borrar(Factura!);
                CargarClientes();
                CargarEmpleados();
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
                CargarClientes();
                CargarEmpleados();
                Factura = Lista!.FirstOrDefault(x => x.Id == data);
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
            CargarClientes();
            CargarEmpleados();
            OnPostBtRefrescar();
            Borrando = false;
        }
        public IActionResult OnGetDescargarPdf(int id)
        {
            var factura = iFacturasNegocio!.Consultar().FirstOrDefault(x => x.Id == id);
            if (factura == null)
                return NotFound();
            
            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(15));

                    page.Header().Element(c => ComposeHeader(c, factura));

                    page.Content().Element(c => ComposeContent(c, factura));

                    page.Footer().AlignLeft().Text(text =>
                    {
                        text.Span("Pagina ");
                        text.CurrentPageNumber();
                    });
                });
            });
            var pdfBytes = pdf.GeneratePdf();
            return File(pdfBytes, "application/pdf", $"factura_{factura.Numero}.pdf");
        }

        void ComposeHeader(IContainer container, Facturas facturas)
        {
            container.Column(column =>
            {
                column.Item().AlignCenter().Text("CONSECIONARIO DE MOTOS").FontSize(25).Bold().FontColor(Colors.Black);
                column.Item().Text($"Factura Numero: {facturas.Numero}").FontSize(20);
                column.Item().Text($"Fecha Vencimiento: {facturas.FechaVencimiento:dd/MM/yyyy}");
                column.Item().Text($"Cliente: {facturas._Clientes?.Nombre ?? "NN"}");
                column.Item().Text($"Empleado: {facturas._Empleados?.Nombre ?? "NN"}");
            });
        }

        void ComposeContent(IContainer container, Facturas facturas)
        {
            container.Column(column =>
            {
                column.Spacing(10);

                if(facturas.Pagos != null && facturas.Pagos.Any())
                {
                    column.Item().Text("HISTORIAL DE PAGOS").Bold().FontSize(15);

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(3);

                        });
                        table.Header(header =>
                        {
                            header.Cell().Text("Fecha").Bold();
                            header.Cell().Text("Monto").Bold();
                        });
                        foreach(var pago in facturas.Pagos)
                        {
                            table.Cell().Text(pago.Fecha.ToString("dd/MM/yyyy"));
                            table.Cell().Text(pago.Monto.ToString("C"));
                        }
                    });
                }
                column.Item().Text("");
                column.Item().Text($"Total Factura: {facturas.Total:C}").FontSize(12);
                column.Item().Text($"Total pagado: {facturas.TotalPagado:C}").FontColor(Colors.Green.Medium);
                column.Item().Text($"Saldo pendiente: {facturas.SaldoPendiente:C}")
                .FontColor(facturas.SaldoPendiente > 0 ? Colors.Red.Medium : Colors.Green.Medium);

                var colorEstado = facturas.Estado == "Pagada" ? Colors.Green.Medium : Colors.Orange.Medium;
                column.Item().Text($"Estado: {facturas.Estado}").FontColor(colorEstado).Bold().FontSize(14);
            });
        }

         
        }
    }

