using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabalho_2_webForms.Dominio.Data;
using Trabalho_2_webForms.Dominio.Entidades;
using Trabalho_2_webForms.Dominio.Infra;
using Trabalho_2_webForms.Dominio.Infra.Extensoes;
using Trabalho_2_webForms.Paginas.Common;

namespace Trabalho_2_webForms.Paginas.Clientes
{
    public partial class Cadastro : PaginaCadastroBase<Cliente>
    {
        public override void SetarDadosCadastro()
        {
            txtCPF.Text = EntidadeCadastro.CPF;
            txtDataNascimento.Text = EntidadeCadastro.DataNascimento==default(DateTime)? 
                string.Empty: 
                EntidadeCadastro.DataNascimento.ToString("yyyy-MM-dd");

            txtEndereco.Text = EntidadeCadastro.Endereco;
            txtId.Text = EntidadeCadastro.Id.ToString();
            txtNome.Text = EntidadeCadastro.Nome;
            txtTelefone.Text = EntidadeCadastro.Telefone;
        }

        public override void MontarDadosCadastro()
        {
            EntidadeCadastro.CPF = txtCPF.Text;
            EntidadeCadastro.DataNascimento = txtDataNascimento.ObterDataOuPadrao();
            EntidadeCadastro.Endereco = txtEndereco.Text;
            EntidadeCadastro.Nome = txtNome.Text;
            EntidadeCadastro.Telefone = txtTelefone.Text;
        }
    }
}