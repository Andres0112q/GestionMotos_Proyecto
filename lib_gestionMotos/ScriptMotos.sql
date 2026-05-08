use db_inventariomotos
go

-- Tabla: CategoriaRepuestos
CREATE TABLE CategoriaRepuestos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(30) NOT NULL,
	Descripcion NVARCHAR(60) NOT NULL,
	FechaCreacion SMALLDATETIME NOT NULL,
	Activo BIT NOT NULL
)
-- Tabla: Clientes
CREATE TABLE Clientes(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(40) NOT NULL,
	Cedula NVARCHAR(30) NOT NULL,
	Telefono NVARCHAR(20) NOT NULL,
	Correo NVARCHAR(40) NOT NULL
)
-- Tabla: Empleados
CREATE TABLE Empleados(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(30) NOT NULL,
	Cedula NVARCHAR(20) NOT NULL,
	Cargo NVARCHAR(30) NOT NULL,
	Telefono NVARCHAR(20) NOT NULL
)
-- Tabla: EstadoOrdenCompras
CREATE TABLE EstadoOrdenCompras(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Estado NVARCHAR(30) NOT NULL
)
-- Tabla: Marcas
CREATE TABLE Marcas(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(30) NOT NULL,
	Referencia NVARCHAR(25) NOT NULL
)
-- Tabla: MetodosDePagos
CREATE TABLE MetodosDePagos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Metodo NVARCHAR(30) NOT NULL,
	Descripcion NVARCHAR(60) NOT NULL,
	EsDigital BIT,
	ReferenciaInterna NVARCHAR(30) NOT NULL
)
-- Tabla: Proveedores
CREATE TABLE Proveedores(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(50) NOT NULL,
	Telefono NVARCHAR(20) NOT NULL,
	Correo NVARCHAR(40) NOT NULL,
	Direccion NVARCHAR(40) NOT NULL
)
-- Tabla: Modelos
CREATE TABLE Modelos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Año SMALLDATETIME NOT NULL,
	Referencia NVARCHAR(20) NOT NULL,
	Tipo NVARCHAR(20) NOT NULL,
	MarcasId INT NOT NULL FOREIGN KEY REFERENCES Marcas(Id)
)
-- Tabla: Motos
CREATE TABLE Motos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Placa NVARCHAR(20) NOT NULL,
	ModelosId INT NOT NULL FOREIGN KEY REFERENCES Modelos(Id),
	MarcasId INT NOT NULL FOREIGN KEY REFERENCES Marcas(Id),
	Valor DECIMAL(18,0)
)
-- Tabla: UnidadesDeMedidas
CREATE TABLE UnidadesDeMedidas(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Sigla NVARCHAR(20) NOT NULL
)

-- Tabla: Repuestos
CREATE TABLE Repuestos (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Codigo NVARCHAR(20),
	Nombre NVARCHAR(30),
	Precio Decimal(18,2) NOT NULL,
	CategoriaRepuestosId INT NOT NULL FOREIGN KEY REFERENCES CategoriaRepuestos(Id),
	PasilloUbicacion NVARCHAR(20)
)

-- Tabla: InventarioMotos
CREATE TABLE InventarioMotos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Cantidad INT NOT NULL,
	Estado NVARCHAR(40),
	MotosId INT NOT NULL FOREIGN KEY REFERENCES Motos(Id),
	UltimoConteo DATETIME NOT NULL
)
-- Tabla: StockRepuestos
CREATE TABLE StockRepuestos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Actual INT NOT NULL,
	Minimo INT NOT NULL,
	Maximo INT NOT NULL,
	RepuestosId INT NOT NULL FOREIGN KEY REFERENCES Repuestos(Id),
	UltimaRevision DATETIME NOT NULL
)
-- Tabla: OrdenCompras
CREATE TABLE OrdenCompras(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Numero NVARCHAR(30),
	Total DECIMAL(12,2) NOT NULL,
	ProveedoresId INT NOT NULL FOREIGN KEY REFERENCES Proveedores(Id),
	EstadoOrdenComprasId INT NOT NULL FOREIGN KEY REFERENCES EstadoOrdenCompras(Id),
	FechaEmision DATETIME NOT NULL
)

-- Tabla: DetalleOrdenCompras
CREATE TABLE DetalleOrdenCompras(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Cantidad INT NOT NULL,
	Subtotal DECIMAL(12,2) NOT NULL,
	RepuestosId INT NOT NULL FOREIGN KEY REFERENCES Repuestos(Id),
	OrdenComprasId INT NOT NULL FOREIGN KEY REFERENCES OrdenCompras(Id),
	PrecioUnitario DECIMAL(18,2) NOT NULL
)

-- Tabla: MovimientosInventarios
CREATE TABLE MovimientosInventarios(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Tipo NVARCHAR(30),
	Cantidad INT NOT NULL,
	Fecha DATETIME NOT NULL,
	EmpleadosId INT NOT NULL FOREIGN KEY REFERENCES Empleados(Id),
	AlmacenOrigen NVARCHAR(40)

)
-- Tabla: DevolucionProveedores
CREATE TABLE DevolucionProveedores(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Radicado NVARCHAR(30),
	Motivo NVARCHAR(60),
	ProveedoresId INT NOT NULL FOREIGN KEY REFERENCES Proveedores(Id),
	Reembolso DECIMAL(18,2) NOT NULL,
	EstadoTramite NVARCHAR(20)
)

-- Tabla: DetalleDevoluciones
CREATE TABLE DetalleDevoluciones(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Cantidad INT NOT NULL,
	Defecto NVARCHAR(40),
	RepuestosId INT NOT NULL FOREIGN KEY REFERENCES Repuestos(Id),
	DevolucionProveedoresId INT NOT NULL FOREIGN KEY REFERENCES DevolucionProveedores(Id),
	RequiereCambio BIT NOT NULL
)

-- Tabla: Facturas
CREATE TABLE Facturas(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Numero NVARCHAR(20),
	Total DECIMAL(18,2) NOT NULL,
	ClientesId INT NOT NULL FOREIGN KEY REFERENCES Clientes(Id),
	EmpleadosId INT NOT NULL FOREIGN KEY REFERENCES Empleados(Id),
	FechaVencimiento DATETIME NOT NULL
)
-- Tabla: PagoFacturas
CREATE TABLE PagoFacturas(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Monto DECIMAL(18,2) NOT NULL,
	Fecha DATETIME NOT NULL,
	Comprobante NVARCHAR(20),
	FacturasId INT NOT NULL FOREIGN KEY REFERENCES Facturas(Id),
	MetodosDePagosId INT NOT NULL FOREIGN KEY REFERENCES MetodosDePagos(Id)
)

-- Tabla: Roles
CREATE TABLE Roles(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(40),
	Descripcion NVARCHAR(300)
)

-- Tabla: Usuarios 
CREATE TABLE Usuarios(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(50),
	Contraseña NVARCHAR(60),
	RolesId INT NOT NULL FOREIGN KEY REFERENCES Roles(Id)
)

-- Tabla : Auditorias
CREATE TABLE Auditorias(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Entidad NVARCHAR(50),
	Accion NVARCHAR(20),
	Fecha DATETIME NOT NULL,
	Descripcion NVARCHAR(300),
	UsuariosId INT NOT NULL FOREIGN KEY REFERENCES Usuarios(Id)
)

-- Tabla: Sucursales
CREATE TABLE Sucursales(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Ciudad NVARCHAR(30) NOT NULL,
	Direccion NVARCHAR(40) NOT NULL,
)

-- Tabla: Garantias
CREATE TABLE Garantias(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Activo BIT,
	FechaInicio DATETIME NOT NULL,
	FechaVencimiento DATETIME NOT NULL,
	DuracionAños INT NOT NULL,
	DescripcionEstado NVARCHAR(50),
	MotosId INT NOT NULL FOREIGN KEY REFERENCES Motos(Id)
)

--Inserciones

INSERT INTO Roles (Nombre,Descripcion)VALUES
('Administrador', 'Tiene acceso total al sistema y puede gestionar usuarios, inventario y ventas '),
('Vendedor', 'Se encarga de atender clientes, registrar ventas y generar facturas')

INSERT INTO Usuarios (Nombre, Contraseña, RolesId) VALUES
('adminC', '1234', 1),
('vendedorL', '1234', 2)

INSERT INTO Sucursales (Ciudad, Direccion) VALUES
('Medellín', 'Calle 10 #20-30'),
('Bogotá', 'Carrera 7 #50-20'),
('Cali', 'Avenida 6 #43-12')

INSERT INTO CategoriaRepuestos (Nombre, Descripcion, FechaCreacion, Activo) VALUES
('Motor', 'Repuestos internos', '2026-03-17', 1),
('Frenos', 'Pastillas y discos', '2026-03-17', 1),
('Suspension', 'Amortiguadores', '2026-03-17', 1),
('Transmisión', 'Cadenas y kit de arrastre', '2026-03-17', 1),
('Eléctrico', 'Baterías y luces', '2026-03-17', 1)

INSERT INTO Clientes (Nombre, Cedula, Telefono, Correo) VALUES
('Andres Rivero', '109234', '31678462', 'andres@gmail.com'),
('Valeria Gomez', '108436', '31870474', 'valeria@gmail.com'),
('Jaime Hernandez', '109645', '32098662', 'jaime@gmail.com'),
('Sebastian Claro', '109967', '31996562', 'sebastian@gmail.com'),
('Naomi Gomez', '108954', '31567453', 'naomi@gmail.com')

INSERT INTO Empleados (Nombre, Cedula, Cargo, Telefono) VALUES
('Carlos Ramirez', '1032456789', 'Administrador', '3004567890'),
('Laura Gómez', '1019876543', 'Vendedor', '3012345678'),
('Andrés Martínez', '1023456781', 'Auxiliar de Inventario', '3029876543'),
('Daniela Torres', '1004567892', 'Cajero', '3045678912'),
('Julián Herrera', '1098765432', 'Técnico Mecánico', '3056789123')

INSERT INTO EstadoOrdenCompras (Estado) VALUES
('Pendiente'),
('Aprobada'),
('Recibida'),
('En proceso'),
('Finalizada')

INSERT INTO Marcas (Nombre, Referencia) VALUES
('Yamaha', 'YZF-R3'),
('Suzuki', 'GSX-R150'),
('AKT', 'NKD 125'),
('KTM', 'Duke 200'),
('BMW', 'G 310 R')

INSERT INTO MetodosDePagos (Metodo, Descripcion, EsDigital, ReferenciaInterna) VALUES
('Efectivo', 'Pago realizado con dinero fisico', 0, 'EF-001'),
('Tarjeta Débito', 'Pago con tarjeta débito bancaria', 1, 'TD-002'),
('Tarjeta Crédito', 'Pago con tarjeta crédito', 1, 'TC-003'),
('Transferencia', 'Pago por transferencia electrónica', 1, 'TR-004'),
('Nequi', 'Pago mediante billetera digital Nequi', 1, 'NQ-005')

INSERT INTO Proveedores (Nombre, Telefono, Correo, Direccion) VALUES
('Distribuidora Yamaha Colombia', '3001234567', 'ventas@yamaha.com.co', 'Medellín, Antioquia'),
('Repuestos Honda S.A.', '3019876543', 'contacto@honda.com.co', 'Bogotá, Cundinamarca'),
('Importadora Bajaj', '3024567890', 'pedidos@bajaj.com.co', 'Cali, Valle del Cauca'),
('Repuestos AKT Oficial', '3041122334', 'soporte@aktmotos.com', 'Barranquilla, Atlántico'),
('MotoPartes Nacionales', '3055566778', 'ventas@motopartes.com.co', 'Medellín, Antioquia')

INSERT INTO Modelos (Año, Referencia, Tipo, MarcasId) VALUES
('2023-01-01', 'YZF-R3', 'Deportiva', 1),
('2025-01-01', 'GSX-R150', 'Deportiva', 2),
('2022-01-01', 'NKD 125', 'Urbana', 3),
('2026-01-01', 'Duke 200', 'Naked', 4),
('2021-01-01', 'G 310 R', 'Naked', 5)

INSERT INTO Motos (Placa, ModelosId, MarcasId, Valor) VALUES
('ABC123', 1, 1, 25000000),
('DEF456', 2, 2, 18000000),
('GHI789', 3, 3, 7500000),
('JKL321', 4, 4, 15000000),
('MNO654', 5, 5, 28000000)

INSERT INTO UnidadesDeMedidas (Sigla) VALUES
('KG'),
('UND'),
('LT'),
('MT'),
('CJ')

INSERT INTO Repuestos (Codigo, Nombre, Precio, CategoriaRepuestosId, PasilloUbicacion) VALUES
('REP001', 'Filtro de aire',     35000.00,  1, 'A1'),
('REP002', 'Pastillas de freno', 85000.00,  1, 'A2'),
('REP003', 'Aceite de motor',    45000.00,  2, 'B1'),
('REP004', 'Cadena transmision', 120000.00, 2, 'B2'),
('REP005', 'Bujia',25000.00,  3, 'C1')

INSERT INTO InventarioMotos (Cantidad, Estado, MotosId, UltimoConteo) VALUES
(5,  'Disponible',    1, '2026-01-15'),
(3,  'Disponible',    2, '2026-01-15'),
(0,  'Agotado',       3, '2026-01-15'),
(8,  'Disponible',    4, '2026-02-01'),
(2,  'Pocas unidades',5, '2026-02-01')

INSERT INTO StockRepuestos (Actual, Minimo, Maximo, RepuestosId, UltimaRevision) VALUES
(50, 10, 100, 1, '2026-01-10'),
(30, 5,  80,  2, '2026-01-10'),
(20, 5,  60,  3, '2026-01-12'),
(15, 5,  50,  4, '2026-01-12'),
(40, 10, 90,  5, '2026-01-15')

INSERT INTO OrdenCompras (Numero, Total, ProveedoresId, EstadoOrdenComprasId, FechaEmision) VALUES
('OC-001', 500000.00,  1, 1, '2026-01-05'),
('OC-002', 300000.00,  2, 1, '2026-01-10'),
('OC-003', 750000.00,  3, 2, '2026-01-15'),
('OC-004', 120000.00,  1, 2, '2026-02-01'),
('OC-005', 980000.00,  4, 3, '2026-02-10')

INSERT INTO DetalleOrdenCompras (Cantidad, Subtotal, RepuestosId, OrdenComprasId, PrecioUnitario) VALUES
(10, 350000.00, 1, 1, 35000.00),
(5,  425000.00, 2, 2, 85000.00),
(20, 900000.00, 3, 3, 45000.00),
(3,  360000.00, 4, 4, 120000.00),
(8,  200000.00, 5, 5, 25000.00)

INSERT INTO MovimientosInventarios (Tipo, Cantidad, Fecha, EmpleadosId, AlmacenOrigen) VALUES
('Entrada',   10, '2026-01-06', 1, 'Almacen Principal'),
('Salida',    5,  '2026-01-11', 2, 'Almacen Principal'),
('Traslado',  3,  '2026-01-16', 4, 'Almacen Secundario'),
('Entrada',   20, '2026-02-02', 3, NULL),
('Salida',    8,  '2026-02-11', 2, 'Almacen Principal')

INSERT INTO DevolucionProveedores (Radicado, Motivo, ProveedoresId, Reembolso, EstadoTramite) VALUES
('RAD-001', 'Producto defectuoso',   1, 35000.00,  'En proceso'),
('RAD-002', 'Producto incorrecto',   2, 85000.00,  'Aprobado'),
('RAD-003', 'Producto vencido',      3, 45000.00,  'Rechazado'),
('RAD-004', 'Cantidad incorrecta',   5, 120000.00, 'En proceso'),
('RAD-005', 'Daño en el embalaje',   2, 25000.00,  'Aprobado')

INSERT INTO DetalleDevoluciones (Cantidad, Defecto, RepuestosId, DevolucionProveedoresId, RequiereCambio) VALUES
(2, 'Filtro roto',         1, 1, 1),
(1, 'Pastillas ralladas',  2, 2, 1),
(3, 'Aceite contaminado',  3, 3, 0),
(1, 'Cadena oxidada',      4, 4, 1),
(4, 'Bujia sin empaque',   5, 5, 0)

INSERT INTO Facturas (Numero, Total, ClientesId, EmpleadosId, FechaVencimiento) VALUES
('FAC-001', 850000.00,  1, 1, '2026-02-05'),
('FAC-002', 1200000.00, 2, 2, '2026-02-10'),
('FAC-003', 450000.00,  3, 4, '2026-02-15'),
('FAC-004', 2300000.00, 4, 3, '2026-03-01'),
('FAC-005', 670000.00,  5, 5, '2026-03-10')

INSERT INTO PagoFacturas (Monto, Fecha, Comprobante, FacturasId, MetodosDePagosId) VALUES
(850000.00,  '2026-01-20', 'COMP-001', 1, 1),
(600000.00,  '2026-01-25', 'COMP-002', 2, 2),
(450000.00,  '2026-02-01', NULL,       3, 1),
(2300000.00, '2026-02-10', 'COMP-003', 4, 3),
(670000.00,  '2026-02-15', NULL,       5, 2)