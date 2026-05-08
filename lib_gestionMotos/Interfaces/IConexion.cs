

using lib_gestionMotos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_gestionMotos.Interfaces
{
    public interface IConexion
    {

        String? StringConexion { get; set; }
        DbSet<Modelos>? Modelos { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Marcas>? Marcas { get; set; }
        DbSet<UnidadesDeMedidas>? UnidadesDeMedidas { get; set; }
        DbSet<EstadoOrdenCompras>? EstadoOrdenCompras { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<CategoriaRepuestos>? CategoriaRepuestos { get; set; }
        DbSet<MetodosDePagos>? MetodosDePagos { get; set; }
        DbSet<Motos>? Motos { get; set; }
        DbSet<Repuestos>? Repuestos { get; set; }
        DbSet<InventarioMotos>? InventarioMotos  { get; set; }
        DbSet<StockRepuestos>? StockRepuestos { get; set; }
        DbSet<OrdenCompras>? OrdenCompras { get; set; }
        DbSet<DetalleOrdenCompras>? DetalleOrdenCompras { get; set; }
        DbSet<MovimientosInventarios>? MovimientosInventarios { get; set; }
        DbSet<DevolucionProveedores>? DevolucionProveedores { get; set; }
        DbSet<DetalleDevoluciones>? DetalleDevoluciones { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<PagoFacturas>? PagoFacturas { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }
        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<Garantias>? Garantias { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

    }
}
