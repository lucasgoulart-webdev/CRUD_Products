Lucas Goulart Baumgratz e Arthur Ferreira

aqui a esrtura do meu banco que utilizei para este projeto:

#Criar a base de dados + Tabelas;
CREATE DATABASE CRUD_PRODUCTS;

use CRUD_PRODUCTS;

CREATE TABLE `CRUD_PRODUCTS`.`produtos` (
`id` INT NOT NULL AUTO_INCREMENT , 
`nome_jogo` VARCHAR(255) NOT NULL , 
`quantidade` VARCHAR(255) NOT NULL , 
`preco_unidade` VARCHAR(255) NOT NULL , 
`classificacao` VARCHAR(255) NOT NULL ,
PRIMARY KEY (`id`)) 
ENGINE = InnoDB;

#Query de Consulta aos usuarios;
select * from produtos;
