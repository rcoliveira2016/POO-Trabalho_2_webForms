using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Trabalho_2_webForms.Dominio.Entidades;

namespace Trabalho_2_webForms.Dominio.Context.Map
{
    public class PagamentoMap : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoMap()
        {
            ToTable("Pagamento");

            HasKey(x => x.Id);

            HasRequired(x => x.FormaPagamento)
                .WithMany(x=> x.Pagamentos)
                .HasForeignKey(x=> x.IdFormaPagamento);
        }
    }
}