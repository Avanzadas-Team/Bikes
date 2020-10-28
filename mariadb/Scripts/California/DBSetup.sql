CHANGE REPLICATION FILTER
    REPLICATE_DO_TABLE = (produccion.categorias, produccion.marcas, produccion.productos, ventas.clientes, ventas.tiendaCalifornia, ventas.empleadosCalifornia, ventas.ordenesCalifornia, ventas.detalleOrden, produccion.inventarioCalifornia, ventas.ordenes);

CHANGE MASTER TO MASTER_HOST='NewYorkDB',
    MASTER_USER='repl',
    MASTER_PASSWORD='password',
    MASTER_LOG_FILE='mysql-bin.000003',
    MASTER_LOG_POS= 3397327;

start slave;
show slave status;