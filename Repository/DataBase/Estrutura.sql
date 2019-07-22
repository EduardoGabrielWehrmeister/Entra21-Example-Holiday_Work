DROP TABLE  IF EXISTS estados;
CREATE TABLE estados(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	sigla VARCHAR(2),
	data_criacao DATETIME2,
	registro_ativo BIT
);
DROP TABLE cidades;
CREATE TABLE cidades(
	id INT PRIMARY KEY IDENTITY(1,1),
	estado_id INT,
	nome VARCHAR(50),
	numero_habitantes INT,
	CONSTRAINT fk_estado FOREIGN KEY (estado_id) REFERENCES estados(id),
	data_criacao DATETIME2,
	registro_ativo BIT
);
SELECT * FROM cidades;
DROP TABLE clientes;
CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_cidade INT,
	nome VARCHAR(50),
	cpf VARCHAR(50),
	data_nascimento DATETIME2(7),
	numero INT,
	complemento NCHAR(10),
	logradouro NCHAR(10),
	cep NCHAR(10),
	CONSTRAINT fk_cidade FOREIGN KEY (id_cidade) REFERENCES cidades(id),
	data_criacao DATETIME2,
	registro_ativo BIT
);
DROP TABLE	projetos;
CREATE TABLE projetos(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_cliente INT,
	nome VARCHAR(50),
	data_criacao_projeto DATETIME2(7),
	data_finalizacao DATETIME2(7),
	CONSTRAINT fk_cliente FOREIGN KEY (id_cliente) REFERENCES clientes(id),
	data_criacao DATETIME2,
	registro_ativo BIT
);
DROP TABLE usuarios;
CREATE TABLE usuarios(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	login VARCHAR(50),
	senha VARCHAR(50),
	data_criacao DATETIME2,
	registro_ativo BIT
);
DROP TABLE categorias;
CREATE TABLE categorias(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	data_criacao DATETIME2,
	registro_ativo BIT
);
DROP TABLE tarefas;
CREATE TABLE tarefas(
	id INT PRIMARY KEY IDENTITY(1,1),
	id_usuario_responsavel INT,
	id_projeto INT,
	id_categoria INT,
	titulo VARCHAR(50),
	descricao TEXT,
	duracao DATETIME2(7),
	CONSTRAINT fk_usuario_responsavel FOREIGN KEY (id_usuario_responsavel) REFERENCES usuarios(id),
	CONSTRAINT fk_projeto FOREIGN KEY (id_projeto) REFERENCES projetos(id),
	CONSTRAINT fk_categoria FOREIGN KEY (id_categoria) REFERENCES categorias(id),
	data_criacao DATETIME2,
	registro_ativo BIT
);