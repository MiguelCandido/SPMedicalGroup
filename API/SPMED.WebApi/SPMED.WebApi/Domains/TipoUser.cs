using System;
using System.Collections.Generic;

#nullable disable

namespace SPMED.WebApi.Domains
{
    public partial class TipoUser
    {
        public TipoUser()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUser { get; set; }
        public string NomeTipoUser { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
