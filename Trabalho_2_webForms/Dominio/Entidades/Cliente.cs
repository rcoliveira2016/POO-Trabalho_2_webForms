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

        public override string DescricaoCombo => Nome;

        public override bool ValidarDados(out List<string> mensagens)
        {
            if (!base.ValidarDados(out mensagens))
            {
                return false;
            }

            ValidarCampo(mensagens, CPF, "CPF");

            ValidarCampo(mensagens, Nome, "Nome");

            ValidarCampo(mensagens, Endereco, "Endereço");

            ValidarCampo(mensagens, Telefone, "Telefone");

            ValidarCampo(mensagens, DataNascimento, "Data de nascimaneto");

            return !mensagens.Any();
        }
    }
}