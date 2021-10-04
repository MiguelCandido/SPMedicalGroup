using System;
using System.Collections.Generic;

#nullable disable

namespace SPMED.WebApi.Domains
{
    public partial class Telefone
    {
        public int IdTelefone { get; set; }
        public int IdPaciente { get; set; }
        public string NumeroTelefone { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
