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


        public override string DescricaoCombo => Nome;

        public override bool ValidarDados(out List<string> mensagens)
        {
            if (!base.ValidarDados(out mensagens))
            {
                return false;
            }

            ValidarCampo(mensagens, Nome, "Nome");

            ValidarCampo(mensagens, Descricao, "Descrição");

            ValidarCampo(mensagens, ValorUnitario, "Valor Unitario");

            return !mensagens.Any();
        }
    }
}