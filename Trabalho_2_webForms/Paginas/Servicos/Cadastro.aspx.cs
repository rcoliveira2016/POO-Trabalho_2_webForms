using System;
using Trabalho_2_webForms.Dominio.Entidades;
using Trabalho_2_webForms.Dominio.Infra.Extensoes;
using Trabalho_2_webForms.Paginas.Common;
using static Trabalho_2_webForms.Dominio.Infra.RepositorioSingleton;

namespace Trabalho_2_webForms.Paginas.Servicos
{
    public partial class Cadastro : PaginaBase, IPaginaCadastroBase
    {

        public Servico EntidadeCadastro
        {
            get
            {
                return (Session["Servico"] ?? (Session["Servico"] == new Servico())) as Servico;
            }
            set
            {
                Session["Servico"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TentarObterEntidadeIdUrl(ServicoRepositorio, out var entidadeExistente);
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

                ServicoRepositorio.Salvar(EntidadeCadastro);
                AdicionarTextoSucesso("Salvo com Sucesso");
            });
        }

        public void LimparCampos()
        {

        }

        public void SetarDadosCadastro()
        {
            txtNome.Text = EntidadeCadastro.Nome;
            txtDescricao.Text = EntidadeCadastro.Descricao;
            txtValorUnitario.Text = EntidadeCadastro.ValorUnitario.ToString();
            txtId.Text = EntidadeCadastro.Id.ToString();
        }

        public void MontarDadosCadastro()
        {
            EntidadeCadastro.Nome = txtNome.Text;
            EntidadeCadastro.Descricao = txtDescricao.Text;
            if(txtValorUnitario.TentarObterDouble(out var valorUnitario))
                EntidadeCadastro.ValorUnitario = valorUnitario;
        }
    }
}