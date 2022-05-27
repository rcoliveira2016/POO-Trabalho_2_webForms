using System;
using Trabalho_2_webForms.Dominio.Entidades;
using Trabalho_2_webForms.Paginas.Common;
using static Trabalho_2_webForms.Dominio.Infra.RepositorioSingleton;

namespace Trabalho_2_webForms.Paginas.Usuarios
{
    public partial class Cadastro : PaginaBase, IPaginaCadastroBase
    {

        public Usuario EntidadeCadastro
        {
            get
            {
                return (Session["Usuario"] ?? (Session["Usuario"] == new Usuario())) as Usuario;
            }
            set
            {
                Session["Usuario"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TentarObterEntidadeIdUrl(UsuarioRepositorio, out var entidadeExistente);
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

                UsuarioRepositorio.Salvar(EntidadeCadastro);
                AdicionarTextoSucesso("Salvo com Sucesso");
            });
        }

        public void LimparCampos()
        {

        }

        public void SetarDadosCadastro()
        {
            txtNome.Text = EntidadeCadastro.NomeCompleto;
            txtLogin.Text = EntidadeCadastro.Login;
            txtSenha.Text = EntidadeCadastro.Senha;
            txtId.Text = EntidadeCadastro.Id.ToString();
        }

        public void MontarDadosCadastro()
        {
            EntidadeCadastro.NomeCompleto = txtNome.Text;
            EntidadeCadastro.Login = txtLogin.Text;
            EntidadeCadastro.Senha = txtSenha.Text;
        }
    }
}