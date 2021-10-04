using SPMED.WebApi.Contexts;
using SPMED.WebApi.Domains;
using SPMED.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPMEDContext ctx = new SPMEDContext();
        public void Atualizar(int idClinica, Clinica clinicaU)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(idClinica);

            if (clinicaU.NomeClinica != null) { clinicaBuscada.NomeClinica = clinicaU.NomeClinica; }
            if (clinicaU.Cnpj != null) { clinicaBuscada.Cnpj = clinicaU.Cnpj; }
            if (clinicaU.RazaoSocial != null) { clinicaBuscada.RazaoSocial = clinicaU.RazaoSocial; }
            if (clinicaU.Endereco != null) { clinicaBuscada.Endereco = clinicaU.Endereco; }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorID(int idclinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == idclinica);
        }

        public void Cadastrar(Clinica NovaClinica)
        {
            ctx.Clinicas.Add(NovaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica clinicaBuscada = BuscarPorID(idClinica);


            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
