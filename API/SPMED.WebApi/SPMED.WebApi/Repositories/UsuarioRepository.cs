using SPMED.WebApi.Contexts;
using SPMED.WebApi.Domains;
using SPMED.WebApi.Interfaces;
using SPMED.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        SPMEDContext ctx = new SPMEDContext();
        public void Atualizar(int idUsuario, Usuario usuarioU)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(idUsuario);

            if (usuarioU.NomeUsuario != null) { usuarioBuscado.NomeUsuario = usuarioU.NomeUsuario; }
            if (usuarioU.IdTipoUser != 0) { usuarioBuscado.IdTipoUser = usuarioU.IdTipoUser; }
            if (usuarioU.Email != null) { usuarioBuscado.Email = usuarioU.Email; }
            if (usuarioU.Senha != null) { usuarioBuscado.Senha = usuarioU.Senha; }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorID(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(s => s.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);

            ctx.SaveChanges();

        }

        public void Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorID(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario login(LoginViewModel cred)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == cred.Email && u.Senha == cred.Senha);
        }
    }
}
