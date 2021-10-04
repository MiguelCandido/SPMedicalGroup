using SPMED.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Interfaces
{
    interface IMedicoRepository
    {
    

        /// <summary>
        /// Cadastra um novo Medico
        /// </summary>
        /// <param name="novoMedico">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualiza os dados de um Medico
        /// </summary>
        /// <param name="idMedico">ID do Medico a ser atualizado</param>
        /// <param name="MedicoU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idMedico, Medico MedicoU);

        /// <summary>
        /// Deleta um Medico
        /// </summary>
        /// <param name="idMedico">ID do Medico a ser deletado</param>
        void Deletar(int idMedico);

        public Medico BuscarPorID(int idMedico);

        public List<Medico> Listar();
    }
}
