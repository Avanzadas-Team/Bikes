CHANGE REPLICATION FILTER
    REPLICATE_DO_TABLE = (produccion.categorias, produccion.marcas, produccion.productos, ventas.clientes, ventas.tiendaTexas, ventas.empleadosTexas, ventas.ordenesTexas, ventas.detalleOrdenTexas, produccion.inventarioTexas, ventas.ordenes);

CHANGE MASTER TO MASTER_HOST='NewYorkDB',
    MASTER_USER='repl',
    MASTER_PASSWORD='password',
    MASTER_LOG_FILE='Inserte el nombre del LOGFile obtenido del Master',
    MASTER_LOG_POS= Insertar el pos obtenido del master;

start slave;
show slave status;