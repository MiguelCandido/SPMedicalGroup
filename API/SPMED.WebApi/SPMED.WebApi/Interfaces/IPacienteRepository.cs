using SPMED.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Interfaces
{
    interface IPacienteRepository
    {

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Atualiza os dados de um paciente
        /// </summary>
        /// <param name="idPaciente">ID do paciente a ser atualizado</param>
        /// <param name="pacienteU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idPaciente, Paciente pacienteU);

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="idPaciente">ID do paciente a ser deletado</param>
        void Deletar(int idPaciente);

        public Paciente BuscarPorID(int idPaciente);

        public List<Paciente> Listar();
    }
}
