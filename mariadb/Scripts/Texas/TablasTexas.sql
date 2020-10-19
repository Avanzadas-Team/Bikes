
-- create schemas
CREATE SCHEMA produccion;

CREATE SCHEMA ventas;

-- create tables
CREATE TABLE produccion.categorias (
	idCategoria INT AUTO_INCREMENT  PRIMARY KEY,
	descripcion VARCHAR (255) NOT NULL
);

CREATE TABLE produccion.marcas (
	idMarca INT AUTO_INCREMENT PRIMARY KEY,
	nomMarca VARCHAR (255) NOT NULL
);

CREATE TABLE produccion.productos (
	idProducto INT AUTO_INCREMENT PRIMARY KEY,
	nomProducto VARCHAR (255) NOT NULL,
	idMarca INT NOT NULL,
	idCategoria INT NOT NULL,
	annoModelo SMALLINT NOT NULL,
	precioVenta DECIMAL (10, 2) NOT NULL,
	FOREIGN KEY (idCategoria) REFERENCES produccion.categorias (idCategoria) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (idMarca) REFERENCES produccion.marcas (idMarca) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ventas.clientes (
	idCliente INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR (255) NOT NULL,
	apellido VARCHAR (255) NOT NULL,
	telefono VARCHAR (25),
	email VARCHAR (255) NOT NULL,
	calle VARCHAR (255),
	ciudad VARCHAR (50),
	estado VARCHAR (25),
	codPostal VARCHAR (5)
);


CREATE TABLE ventas.tiendaTexas (
	idTienda INT PRIMARY KEY,
	nomTienda VARCHAR (255) NOT NULL,
	telefono VARCHAR (25),
	email VARCHAR (255),
	calle VARCHAR (255),
	ciudad VARCHAR (255),
	estado VARCHAR (10),
	codPostal VARCHAR (5)
);


CREATE TABLE ventas.empleadosTexas (
	idEmpleado INT PRIMARY KEY,
	nombre VARCHAR (50) NOT NULL,
	apellido VARCHAR (50) NOT NULL,
	email VARCHAR (255) NOT NULL UNIQUE,
	telefono VARCHAR (25),
	activo tinyint NOT NULL,
	idTienda INT NOT NULL,
	idJefe INT,
	FOREIGN KEY (idTienda) REFERENCES ventas.tiendaTexas (idTienda) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ventas.ordenes(
	idOrden INT AUTO_INCREMENT PRIMARY KEY
);

CREATE TABLE ventas.ordenesTexas (
	idOrden INT PRIMARY KEY,
	idCliente INT,
	estadoOrden tinyint NOT NULL,
	-- Order status: 1 = Pending; 2 = Processing; 3 = Rejected; 4 = Completed
	fechaOrden DATE NOT NULL,
	required_date DATE NOT NULL,
	fechaEnvio DATE,
	idTienda INT NOT NULL,
	idEmpleado INT NOT NULL,
	FOREIGN KEY (idOrden) REFERENCES ventas.ordenes (idOrden),
	FOREIGN KEY (idCliente) REFERENCES ventas.clientes (idCliente) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (idTienda) REFERENCES ventas.tiendaTexas (idTienda) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (idEmpleado) REFERENCES ventas.empleadosTexas (idEmpleado) ON DELETE NO ACTION ON UPDATE NO ACTION
);


CREATE TABLE ventas.detalleOrdenTexas (
	idOrden INT,
	idItem INT,
	idProducto INT NOT NULL,
	cantidad INT NOT NULL,
	precioVenta DECIMAL (10, 2) NOT NULL,
	descuento DECIMAL (4, 2) NOT NULL DEFAULT 0,
	PRIMARY KEY (idOrden, idItem),
	FOREIGN KEY (idOrden) REFERENCES ventas.ordenes (idOrden) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (idProducto) REFERENCES produccion.productos (idProducto) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE produccion.inventarioTexas (
	idTienda INT,
	idProducto INT,
	cantidad INT,
	PRIMARY KEY (idTienda, idProducto),
	FOREIGN KEY (idTienda) REFERENCES ventas.tiendaTexas (idTienda) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (idProducto) REFERENCES produccion.productos (idProducto) ON DELETE CASCADE ON UPDATE CASCADE
);