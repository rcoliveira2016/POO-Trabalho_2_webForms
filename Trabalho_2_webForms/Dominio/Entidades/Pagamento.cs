using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_2_webForms.Dominio.Entidades
{
    public class Pagamento: Entidade
    {        
        public virtual ICollection<OrdemServico> OrdensServicos { get; set; }
        public long IdFormaPagamento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        public double ValorTotal { get; set; }
    }
}