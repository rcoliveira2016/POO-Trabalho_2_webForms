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

        public override string DescricaoCombo => NomeCompleto;

        public override bool ValidarDados(out List<string> mensagens)
        {
            if (!base.ValidarDados(out mensagens))
            {
                return false;
            }

            ValidarCampo(mensagens, NomeCompleto, "Nome completo");

            ValidarCampo(mensagens, Login, "Login");

            ValidarCampo(mensagens, Senha, "Senha");

            return !mensagens.Any();
        }
    }
}