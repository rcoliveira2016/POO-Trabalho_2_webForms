using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabalho_2_webForms.Dominio.Entidades;
using Trabalho_2_webForms.Dominio.Infra.Extensoes;
using Trabalho_2_webForms.Paginas.Common;
using static Trabalho_2_webForms.Dominio.Infra.RepositorioSingleton;

namespace Trabalho_2_webForms.Paginas.Clientes
{
    public partial class Cadastro : PaginaBase, IPaginaCadastroBase
    {

        public Cliente EntidadeCadastro
        {
            get { 
                return (Session["Cliente"] ?? (Session["Cliente"] == new Cliente())) as Cliente; 
            }
            set { 
                Session["Cliente"] = value; 
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TentarObterEntidadeIdUrl(ClienteRepositorio, out var entidadeExistente);
                EntidadeCadastro = entidadeExistente;
                SetarDadosCadastro();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TratarCadastro(() =>
            {
                MontarDadosCadastro();
                if (!ValidarEntidaeCadastro(EntidadeCadastro)) return;

                ClienteRepositorio.Salvar(EntidadeCadastro);
                AdicionarTextoSucesso("Salvo com Sucesso");
            });
        }

        public void LimparCampos()
        {
            
        }

        public void SetarDadosCadastro()
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

        public void MontarDadosCadastro()
        {
            EntidadeCadastro.CPF = txtCPF.Text;
            EntidadeCadastro.DataNascimento = txtDataNascimento.ObterDataOuPadrao();
            EntidadeCadastro.Endereco = txtEndereco.Text;
            EntidadeCadastro.Nome = txtNome.Text;
            EntidadeCadastro.Telefone = txtTelefone.Text;
        }
    }
}