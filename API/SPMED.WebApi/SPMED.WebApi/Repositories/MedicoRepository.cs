using SPMED.WebApi.Contexts;
using SPMED.WebApi.Domains;
using SPMED.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SPMEDContext ctx = new SPMEDContext();
        public void Atualizar(int idMedico, Medico MedicoU)
        {
            Medico medicoBuscado = ctx.Medicos.Find(idMedico);

            if (MedicoU.IdEspecialidade != 0) { medicoBuscado.IdEspecialidade = MedicoU.IdEspecialidade; }
            if (MedicoU.IdUsuario != 0) { medicoBuscado.IdUsuario = MedicoU.IdUsuario; }
            if (MedicoU.IdClinica != 0) { medicoBuscado.IdClinica = MedicoU.IdClinica; }
            if (MedicoU.Crm != null) { medicoBuscado.Crm = MedicoU.Crm; }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            Medico medicoBuscado = ctx.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorID(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }
    }
}
