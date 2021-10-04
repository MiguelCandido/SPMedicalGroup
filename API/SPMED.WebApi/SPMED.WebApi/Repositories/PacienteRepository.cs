using SPMED.WebApi.Contexts;
using SPMED.WebApi.Domains;
using SPMED.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SPMEDContext ctx = new SPMEDContext();
        public void Atualizar(int idPaciente, Paciente pacienteU)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(idPaciente);

            if (pacienteU.Cpf != null) { pacienteBuscado.Cpf = pacienteU.Cpf; }
            if (pacienteU.IdUsuario != 0) { pacienteBuscado.IdUsuario = pacienteU.IdUsuario; }
            if (pacienteU.Rg != null) { pacienteBuscado.Rg = pacienteU.Rg; }
            if (pacienteU.EnderecoPaciente != null) { pacienteBuscado.EnderecoPaciente = pacienteU.EnderecoPaciente; }
            if (pacienteU.DataNascimento != DateTime.MinValue) { pacienteBuscado.DataNascimento = pacienteU.DataNascimento; }

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            Paciente pacienteBuscado = ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorID(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
