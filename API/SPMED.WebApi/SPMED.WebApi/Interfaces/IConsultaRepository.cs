using SPMED.WebApi.Domains;
using System.Collections.Generic;

namespace SPMED.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelas consultas
    /// </summary>
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todos as consultas
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        List<Consultum> Listar();

        /// <summary>
        /// Busca uma consulta a partir de um ID
        /// </summary>
        /// <param name="idConsulta">ID da consulta a ser buscada</param>
        /// <returns>Uma consulta encontrada</returns>
        Consultum BuscarPorID(int idConsulta);

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="NovaConsulta">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Consultum NovaConsulta);

        /// <summary>
        /// Atualiza os dados de uma consulta
        /// </summary>
        /// <param name="idConsulta">ID da consulta a ser atualizada</param>
        /// <param name="consultaU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idConsulta, Consultum consultaU);

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="idConsulta">ID da consulta a ser deletada</param>
        void Deletar(int idConsulta);

        void AlterarSituação(int idConsulta, Consultum consulta);

    }
}
