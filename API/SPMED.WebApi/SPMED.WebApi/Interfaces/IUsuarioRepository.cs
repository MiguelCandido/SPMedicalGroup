using SPMED.WebApi.Domains;
using SPMED.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelos usuarios
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuario a partir de um ID
        /// </summary>
        /// <param name="idUsuario">ID do usuario a ser buscada</param>
        /// <returns>Um usuario encontrada</returns>
        Usuario BuscarPorID(int idUsuario);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovoUsuario">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Usuario NovoUsuario);

        /// <summary>
        /// Atualiza os dados de um usuario
        /// </summary>
        /// <param name="idUsuario">ID do usuario a ser atualizado</param>
        /// <param name="usuarioU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idUsuario, Usuario usuarioU);

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="idUsuario">ID do usuario a ser deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Loga o usuário
        /// </summary>
        /// <param name="cred">Credenciais de login</param>
        Usuario login(LoginViewModel cred);
    }
}
