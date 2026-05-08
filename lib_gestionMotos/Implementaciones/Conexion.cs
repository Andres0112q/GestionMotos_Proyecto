
using lib_gestionMotos.Entidades;
using lib_gestionMotos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_gestionMotos.Implementaciones
{
    public class Conexion: DbContext, IConexion
    {
        public String? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Modelos>? Modelos { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<UnidadesDeMedidas>? UnidadesDeMedidas { get; set; }
        public DbSet<EstadoOrdenCompras>? EstadoOrdenCompras { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<CategoriaRepuestos>? CategoriaRepuestos { get; set; }
        public DbSet<MetodosDePagos>? MetodosDePagos { get; set; }
        public DbSet<Motos>? Motos { get; set; }
        public DbSet<InventarioMotos>? InventarioMotos { get; set; }
        public DbSet<Repuestos>? Repuestos { get; set; }
        public DbSet<StockRepuestos>? StockRepuestos { get; set; }
        public DbSet<OrdenCompras>? OrdenCompras { get; set; }
        public DbSet<DetalleOrdenCompras>? DetalleOrdenCompras { get; set; }
        public DbSet<MovimientosInventarios>? MovimientosInventarios { get; set; }
        public DbSet<DevolucionProveedores>? DevolucionProveedores { get; set; }
        public DbSet<DetalleDevoluciones>? DetalleDevoluciones { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<PagoFacturas>? PagoFacturas { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<Garantias>? Garantias { get; set; }
    }
}
