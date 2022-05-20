using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_2_webForms.Dominio.Entidades
{
    public class Servico:Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }
        public virtual ICollection<OrdemServico> OrdensServicos { get; set; }

    }
}