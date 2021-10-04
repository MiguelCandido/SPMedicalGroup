CREATE DATABASE SPMED_BD
GO

USE SPMED_BD
GO

CREATE TABLE tipoUser (
idTipoUser int PRIMARY KEY IDENTITY (1,1),
nomeTipoUser varchar(20) not null
);
GO

CREATE TABLE usuarios (
idUsuario int PRIMARY KEY IDENTITY (1,1),
idTipoUser int FOREIGN KEY REFERENCES tipoUser(idTipoUser) not null , 
nomeUsuario varchar(50)not null,
email varchar(60) not null,
senha varchar(40) not null
);
GO

CREATE TABLE Clinica (
idClinica int PRIMARY KEY IDENTITY (1,1),
nomeClinica varchar(50) not null,
CNPJ varchar(20)not null,
razaoSocial varchar(35)not null,
endereco varchar(100)not null
);
GO

CREATE TABLE especialidade (
idEspecialidade int PRIMARY KEY IDENTITY (1,1),
nomeEspecialidade varchar(30)not null
);
GO

CREATE TABLE medico (
idMedico int PRIMARY KEY IDENTITY (1,1),
idUsuario int FOREIGN KEY REFERENCES usuarios(idUsuario)not null,
idEspecialidade int FOREIGN KEY REFERENCES especialidade(idEspecialidade)not null,
idClinica int FOREIGN KEY REFERENCES Clinica(idClinica)not null,
CRM varchar(10)not null
);
GO

CREATE TABLE paciente (
idPaciente int PRIMARY KEY IDENTITY (1,1),
idUsuario int FOREIGN KEY REFERENCES usuarios(idUsuario)not null,
CPF varchar(20)not null,
RG varchar(20)not null,
dataNascimento DATE not null,
enderecoPaciente varchar(100)not null
);
GO

CREATE TABLE telefone (
idTelefone int PRIMARY KEY IDENTITY (1,1),
idPaciente int FOREIGN KEY REFERENCES paciente(idPaciente)not null,
numeroTelefone varchar(30)not null
);
GO

CREATE TABLE consulta (
idConsulta int PRIMARY KEY IDENTITY (1,1),
idMedico int FOREIGN KEY REFERENCES medico(idMedico)not null,
idPaciente int FOREIGN KEY REFERENCES paciente(idPaciente)not null,
Situacao varchar(20) DEFAULT 'Agendada',
DataConsulta smalldatetime not null,
descricao varchar(200) 
);
GO