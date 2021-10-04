using SPMED.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Interfaces
{
    /// <summary>
    /// Inteface responsável pelas clínicas
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todos as clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca uma clinica a partir de um ID
        /// </summary>
        /// <param name="idclinica">ID da clinica a ser buscada</param>
        /// <returns>Uma clinica encontrada</returns>
        Clinica BuscarPorID(int idclinica);

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="NovaClinica">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Clinica NovaClinica);

        /// <summary>
        /// Atualiza os dados de uma clinica
        /// </summary>
        /// <param name="idClinica">ID da clinica a ser atualizada</param>
        /// <param name="clinicaU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idClinica, Clinica clinicaU);

        /// <summary>
        /// Deleta uma clinica
        /// </summary>
        /// <param name="idClinica">ID da clinica a ser deletada</param>
        void Deletar(int idClinica);
    }
}
