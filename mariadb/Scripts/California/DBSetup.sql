CHANGE REPLICATION FILTER
    REPLICATE_DO_TABLE = (produccion.categorias, produccion.marcas, produccion.productos, ventas.clientes, ventas.tiendaCalifornia, ventas.empleadosCalifornia, ventas.ordenesCalifornia, ventas.detalleOrdenCalifornia, produccion.inventarioCalifornia, ventas.ordenes);

CHANGE MASTER TO MASTER_HOST='NewYorkDB',
    MASTER_USER='repl',
    MASTER_PASSWORD='password',
    MASTER_LOG_FILE='d2abc23666dd-bin.000001',
    MASTER_LOG_POS= 10549;

start slave;
show slave status;