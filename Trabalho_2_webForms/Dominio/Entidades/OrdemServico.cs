using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_2_webForms.Dominio.Entidades
{
    public class OrdemServico : Entidade
    {
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public long IdServico { get; set; }
        public virtual Servico Servico { get; set; }
        public long IdPagamento { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public int Unitario { get; set; }
        public DateTime DataAbertura { get; set; }
    }
}