using System;
using Trabalho_2_webForms.Dominio.Data;
using Trabalho_2_webForms.Dominio.Entidades;
using Trabalho_2_webForms.Dominio.Infra;
using Trabalho_2_webForms.Paginas.Common;

namespace Trabalho_2_webForms.Paginas.Usuarios
{
    public partial class Cadastro : PaginaCadastroBase<Usuario>
    {
        public override void SetarDadosCadastro()
        {
            txtNome.Text = EntidadeCadastro.NomeCompleto;
            txtLogin.Text = EntidadeCadastro.Login;
            txtSenha.Text = EntidadeCadastro.Senha;
            txtId.Text = EntidadeCadastro.Id.ToString();
        }

        public override void MontarDadosCadastro()
        {
            EntidadeCadastro.NomeCompleto = txtNome.Text;
            EntidadeCadastro.Login = txtLogin.Text;
            EntidadeCadastro.Senha = txtSenha.Text;
        }
    }
}