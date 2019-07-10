CREATE TABLE Custo (
	IdCusto INT NOT NULL,
	DescricaoCusto VARCHAR(50) NULL,
	CONSTRAINT PK_Custo PRIMARY KEY (IdCusto)
)

CREATE TABLE Restaurante(
	IdRestaurante INT NOT NULL,
	Nome VARCHAR(50) NULL,
	Apelido VARCHAR(50) NULL,
	Endereco VARCHAR(100) NULL,
	Observacao VARCHAR(100) NULL,
	CONSTRAINT PK_Restaurante PRIMARY KEY (IdRestaurante)
)

CREATE TABLE Tipo(
	IdTipo INT NOT NULL,
	DescricaoTipo VARCHAR(50) NULL,
	CONSTRAINT PK_Tipo PRIMARY KEY (IdTipo)
)

CREATE TABLE Veto(
	IdVeto INT NOT NULL,
	DescricaoVeto VARCHAR(50) NULL,
	CONSTRAINT PK_Veto PRIMARY KEY (IdVeto)
)

CREATE TABLE Restaurante_Custo(
	IdRestaurante INT NOT NULL,
	IdCusto INT NOT NULL,
	CONSTRAINT FK_RestauranteCusto_Restaurante FOREIGN KEY (IdRestaurante) REFERENCES Restaurante (IdRestaurante),
	CONSTRAINT FK_RestauranteCusto_Custo FOREIGN KEY (IdCusto) REFERENCES Custo (IdCusto)
)

CREATE TABLE Restaurante_Tipo(
	IdRestaurante INT NOT NULL,
	IdTipo INT NOT NULL,
	CONSTRAINT FK_RestauranteTipo_Restaurante FOREIGN KEY (IdRestaurante) REFERENCES Restaurante (IdRestaurante),
	CONSTRAINT FK_RestauranteTipo_Tipo FOREIGN KEY (IdTipo) REFERENCES Tipo (IdTipo)
)

CREATE TABLE Restaurante_Veto(
	IdRestaurante INT NOT NULL,
	IdVeto INT NOT NULL,
	CONSTRAINT FK_RestauranteVeto_Restaurante FOREIGN KEY (IdRestaurante) REFERENCES Restaurante (IdRestaurante),
	CONSTRAINT FK_RestauranteVeto_Veto FOREIGN KEY (IdVeto) REFERENCES Veto (IdVeto)
)