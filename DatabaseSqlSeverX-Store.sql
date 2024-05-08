



create database x_Store
use x_Store;


create table Fornecedor(
id_Fornecedor int primary key identity(1,1), 
CNPJ char(14), 
Razao_social varchar(120),
quantidade_produto int,
Descricao varchar(100) not null,
cidade varchar(100) not null,
UF char(2) not null,
Endereco varchar(120) not null,
Bairro varchar(120) not null,
telefone varchar(20) not null,

);

insert into Fornecedor values('1212121212','nome',12,'asasasa','cidade','AB','asasasas','aasasas','168882728');
select * from fornecedor;

create table Produto(
id_produto int primary key identity(1,1), 
Nome varchar(120) not null,
Marca varchar(120) not null,
Codigo_barras char(13) not null,
Preco decimal(20,2) not null,
categoria varchar(100) not null,
Quantidade_estoque int not null, 
DtRegistro date not null,

);



select * from Produto;
INSERT INTO  Produto values('detergente','ype','111111111111',1.00,'limpeza',12,'2022-09-10')

create table Funcionario(
id_Funcionario int primary key identity(1,1), 
Nome varchar(120) not null, 
CPF char(11) not null,
Data_nascimento date not null,
Telefone varchar(20) not null,
Cidade varchar(100) not null,
Endereco varchar(120) not null,
Bairro varchar(120) not null,
UF char(2 ) not null,

);

INSERT INTO (Nome , CPF ,Data_nascimento ,Telefone,Cidade ,Endereco ,Bairro ,UF ) VALUES(@Nome , @CPF ,@Data_nascimento ,@Telefone,@Cidade ,@Endereco ,@Bairro ,@UF )






create table Cliente(
cod_cliente int primary key identity(1,1),
Nome_Sobrenome varchar(120) not null,
CEP varchar(20) not null, 
CPF char(11) not null,
Data_nascimento date not null,
cidade varchar(120) not null,
Endereco varchar(120) not null, 
Telefone varchar(20) not null,
Email varchar(100) not null, 
NºLogradouro varchar(100) not null, 
UF char(2) not null, 
Bairro varchar(120) not null,

);













