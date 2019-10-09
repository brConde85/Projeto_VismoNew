CREATE DATABASE db_loja;
USE db_loja;

GO
CREATE TABLE cliente(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1)
);

CREATE TABLE venda (
codigo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
datas datetime,
id INT NOT NULL,
CONSTRAINT FK_idCliente FOREIGN KEY (id)
	REFERENCES dbo.cliente (id)
);

CREATE TABLE fornecedor(
codFornecedor INT NOT NULL PRIMARY KEY IDENTITY(1,1),
nome NVARCHAR (50) NOT NULL
);

CREATE TABLE produto(
codigo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
nome NVARCHAR (50) NOT NULL,
preco FLOAT NOT NULL,
qtdEstoque INT NOT NULL,
codFornecedor INT NOT NULL,
pchave NVARCHAR (25) NOT NULL,
CONSTRAINT FK_codFornecedor FOREIGN KEY (codFornecedor)
	REFERENCES dbo.fornecedor (codFornecedor)
);

CREATE TABLE produto_venda(
codigoProduto INT NOT NULL,
codigoVenda INT NOT NULL,

CONSTRAINT FK_codProduto FOREIGN KEY (codigoProduto)
	REFERENCES dbo.produto (codigo),

	CONSTRAINT FK_codVenda FOREIGN KEY (codigoVenda)
	REFERENCES dbo.venda (codigo)
);
CREATE TABLE funcionario(
codigo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
logins NVARCHAR(30) NOT NULL UNIQUE,
senha NVARCHAR(20) NOT NULL,
nome NVARCHAR(70) NOT NULL,
cpf NVARCHAR(11) NOT NULL UNIQUE,
statuss NVARCHAR(20),
tipo NVARCHAR (20) NOT NULL
); 

drop table funcionario;

TRUNCATE TABLE dbo.funcionario;

ALTER TABLE dbo.funcionario
	add logins NVARCHAR(30) NOT NULL unique;

	/*utilizar truncate para limpar dados da tabela*/

CREATE TABLE itemReposicao(
codReposicao INT PRIMARY KEY IDENTITY(1,1),
datas date NOT NULL,
codigoProduto INT NOT NULL,
codigoGerente INT NOT NULL,
CONSTRAINT FK_codProdutoReposicao FOREIGN KEY(codigoProduto)
	REFERENCES dbo.produto (codigo),

CONSTRAINT FK_codGerente FOREIGN KEY(codigoGerente)
	REFERENCES dbo.funcionario (codigo)
);
drop table dbo.pagamento,dbo.itemReposicao;
CREATE TABLE pagamento(
codigo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
descricao NVARCHAR(50) NOT NULL,
validade DATE NOT NULL,
codigoGerente INT NOT NULL,
CONSTRAINT FK_codigoGerente FOREIGN KEY (codigoGerente)
	REFERENCES dbo.funcionario (codigo)
);

SELECT * FROM Fornecedor;
select * from Produto;
select * from funcionario;


