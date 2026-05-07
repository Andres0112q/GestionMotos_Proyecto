using lib_gestionMotos.Implementaciones;
using lib_gestionMotos.Interfaces;
using Microsoft.EntityFrameworkCore;


Console.WriteLine("Conexion a base de datos");

IConexion conexion = new Conexion();
conexion.StringConexion = "server=localhost;Integrated Security=True;TrustServerCertificate=true;database=db_inventariomotos;";

var lista_modelos = conexion.Modelos!.ToList();
var lista_empleados = conexion.Empleados!.ToList();
var lista_marcas = conexion.Marcas!.ToList();
var lista_unidades = conexion.UnidadesDeMedidas!.ToList();
var lista_estados = conexion.EstadoOrdenCompras!.ToList();
var lista_clientes = conexion.Clientes!.ToList();
var lista_proveedores = conexion.Proveedores!.ToList();
var lista_categorias = conexion.CategoriaRepuestos!.ToList();  
var lista_metodos = conexion.MetodosDePagos!.ToList();
var lista_motos = conexion.Motos!.ToList();    

    Console.WriteLine("Final");

