USE SPMED_BD
GO

SELECT COUNT(idUsuario) as 'Quantidade de usuários' FROM usuarios
GO

SELECT idPaciente as 'ID do paciente',nomeUsuario as 'Nome do Paciente',FORMAT (dataNascimento , 'MM-dd-yyyy') as 'Data de nascimento' FROM paciente
INNER JOIN usuarios ON usuarios.idUsuario = paciente.idUsuario
GO

CREATE FUNCTION contarMedico(@id int) RETURNS TABLE AS RETURN
SELECT COUNT(idMedico) as 'Qtd. de medicos da especialidade' FROM medico
where idEspecialidade = @id
GO

select * from contarMedico(16)
GO

CREATE PROCEDURE idadePaciente AS 
SELECT idPaciente as 'ID do paciente',nomeUsuario as 'Nome do Paciente', DATEDIFF(year, (dataNascimento),GETDATE()) as 'Idade do paciente' FROM paciente
INNER JOIN usuarios ON usuarios.idUsuario = paciente.idUsuario
GO


EXEC idadePaciente
GO

