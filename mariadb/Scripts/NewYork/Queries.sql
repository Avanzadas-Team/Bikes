use ventas;
select * FROM detalleOrden;


	
	-- NY
	select c.idcliente, count(c.idcliente = s.idcliente) as cantidad from clientes c inner join  ordenesNewYork s on c.idcliente = s.idcliente group by c.idcliente;
	-- CA
	select c.idcliente, count(c.idcliente = s.idcliente) as cantidad from clientes c inner join  ordenesCalifornia s on c.idcliente = s.idcliente group by c.idcliente;
	-- TX
	select c.idcliente, count(c.idcliente = s.idcliente) as cantidad from clientes c inner join  ordenesTexas s on c.idcliente = s.idcliente group by c.idcliente;