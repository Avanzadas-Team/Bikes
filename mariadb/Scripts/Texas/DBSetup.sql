CHANGE REPLICATION FILTER
    REPLICATE_DO_TABLE = (produccion.categorias, produccion.marcas, produccion.productos, ventas.clientes, ventas.tiendaTexas, ventas.empleadosTexas, ventas.ordenesTexas, ventas.detalleOrden, produccion.inventarioTexas, ventas.ordenes);

CHANGE MASTER TO MASTER_HOST='NewYorkDB',
    MASTER_USER='repl',
    MASTER_PASSWORD='password',
    MASTER_LOG_FILE='binlog.000002',
    MASTER_LOG_POS= 10549;

start slave;
show slave status;