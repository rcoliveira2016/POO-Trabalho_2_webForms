using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_2_webForms.Dominio.Entidades
{
    public class Cliente: Entidade
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public virtual ICollection<OrdemServico> OrdensServicos { get; set; }

    }
}