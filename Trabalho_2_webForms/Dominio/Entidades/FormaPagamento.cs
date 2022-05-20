using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_2_webForms.Dominio.Entidades
{
    public class FormaPagamento: Entidade
    {
        public eTipoFormaPagamento Tipo { get; set; }
        public string CodigoPix { get; set; }
        public string CodigoBarra { get; set; }
        public string NumeroCartão { get; set; }
        public string CodigoSegurança { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }

    public enum eTipoFormaPagamento
    {
        Pix,
        Boleto,
        Cartao
    }
}