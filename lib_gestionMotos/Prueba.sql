CREATE DATABASE db_inventariomotos
go
USE db_inventariomotos
go


CREATE TABLE Modelos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Marca NVARCHAR(20) NOT NULL,
	Año SMALLDATETIME NOT NULL,
	Referencia NVARCHAR(20) NOT NULL,
	Tipo NVARCHAR(20) NOT NULL
)

INSERT INTO Modelos (Marca, Año, Referencia, Tipo) 
VALUES
('Yamaha', '2023-12-01', 'YZF-R3', 'Deportiva'),
('Suzuki', '2025-10-12', 'GSX-R150', 'Deportiva'),
('AKT', '2022-09-01', 'NKD 125', 'Urbana'),
('KTM', '2026-01-01', 'Duke 200', 'Naked'),
('BMW', '2021-05-01', 'G 310 R', 'Naked')

SELECT * FROM Modelos