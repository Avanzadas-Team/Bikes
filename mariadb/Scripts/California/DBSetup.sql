CHANGE REPLICATION FILTER
    REPLICATE_DO_TABLE = (produccion.categorias, produccion.marcas, produccion.productos, ventas.clientes, ventas.tiendaCalifornia, ventas.empleadosCalifornia, ventas.ordenesCalifornia, ventas.detalleOrden, produccion.inventarioCalifornia, ventas.ordenes);

CHANGE MASTER TO MASTER_HOST='NewYorkDB',
    MASTER_USER='repl',
    MASTER_PASSWORD='password',
    MASTER_LOG_FILE='4163b9846e1c-bin.000001',
    MASTER_LOG_POS= 738;

start slave;
show slave status;