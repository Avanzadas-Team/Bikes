create user repl@'%' identified by 'password';
grant replication slave on *.* to repl@'%';
flush privileges;
show master status;