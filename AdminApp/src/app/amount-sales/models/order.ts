export interface Order {
  idOrden: number;
  idItem: number;
  idProducto: number;
  cantidad: number;
  precioVenta: number;
  descuento: number;
  idCliente?: number;
  estadoOrden: number;
  fechaOrden: Date;
  requiredDate: Date;
  fechaEnvio?: Date;
  idTienda: number;
  idEmpleado: number;
  clienteNombre: string;
  clienteApellido: string;
  empleadoNombre: string;
  empleadoApellido: string;
  productName: string;
}
