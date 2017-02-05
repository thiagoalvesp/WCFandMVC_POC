use WCF

CREATE TABLE CLIENTE(
	ClienteId Int primary key,
	Nome Varchar(150) NOT NULL,
	Sobrenome varchar(150) NOT NULL,
	Email varchar(100) NOT NULL,
	DataCadastro Datetime NOT NULL,
	ATIVO BIT NOT NULL
)

CREATE TABLE PRODUTO
(
	ProdutoId int primary key,
	Nome Varchar(250) NOT NULL,
	Valor Numeric(18,2) NOT NULL,
	Disponivel BIT NOT NULL,
	ClienteId int
)

ALTER TABLE PRODUTO ADD FOREIGN KEY (ClienteId) 
REFERENCES CLIENTE(ClienteId)
select * from PRODUTO
INSERT INTO CLIENTE VALUES (1,'Thiago','Pereira','thiago-alvesp@live.com',GETDATE(),1)

DELETE PRODUTO