using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_2_webForms.Dominio.Entidades
{
    public class Usuario:Entidade
    {
        public string NomeCompleto { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<OrdemServico> OrdensServicos { get; set; }

    }
}