using System;
using System.Collections.Generic;

#nullable disable

namespace SPMED.WebApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
            Telefones = new HashSet<Telefone>();
        }

        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EnderecoPaciente { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
