using SPMED.WebApi.Contexts;
using SPMED.WebApi.Domains;
using SPMED.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMED.WebApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMEDContext ctx = new SPMEDContext();

        public void AlterarSituação(int idConsulta, Consultum consulta)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(idConsulta);

            switch (consulta.Situacao)
            {
                case "Agendada":
                    consultaBuscada.Situacao = "Agendada";
                    break;
                case "Realizada":
                    consultaBuscada.Situacao = "Realizada";
                    break;
                case "Cancelada":
                    consultaBuscada.Situacao = "Cancelada";
                    break;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();

        }

        public void Atualizar(int idConsulta, Consultum consultaU)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(idConsulta);

            if (consultaU.IdMedico != 0) { consultaBuscada.IdMedico = consultaU.IdMedico; }
            if (consultaU.IdPaciente != 0) { consultaBuscada.IdPaciente = consultaU.IdPaciente; }
            if (consultaU.Situacao != null) { consultaBuscada.Situacao = consultaU.Situacao; }
            if (consultaU.DataConsulta != DateTime.MinValue) { consultaBuscada.DataConsulta = consultaU.DataConsulta; }
            if (consultaU.Descricao != null) { consultaBuscada.Descricao = consultaU.Descricao; }


            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorID(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(con => con.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            Consultum consultaBuscada = BuscarPorID(idConsulta);


            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consultum> Listar()
        {
            return ctx.Consulta.ToList();
        }
    }
}
