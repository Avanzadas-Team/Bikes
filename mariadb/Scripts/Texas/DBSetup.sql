CHANGE REPLICATION FILTER
    REPLICATE_DO_TABLE = (produccion.categorias, produccion.marcas, produccion.productos, ventas.clientes, ventas.tiendaTexas, ventas.empleadosTexas, ventas.ordenesTexas, ventas.detalleOrden, produccion.inventarioTexas, ventas.ordenes);

CHANGE MASTER TO MASTER_HOST='NewYorkDB',
    MASTER_USER='repl',
    MASTER_PASSWORD='password',
    MASTER_LOG_FILE='f565f5d36088-bin.000003',
    MASTER_LOG_POS= 3396781;

start slave;
show slave status;