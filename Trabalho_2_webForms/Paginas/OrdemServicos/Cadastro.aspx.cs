using System;
using Trabalho_2_webForms.Dominio.Entidades;
using Trabalho_2_webForms.Dominio.Infra.Extensoes;
using Trabalho_2_webForms.Paginas.Common;
using static Trabalho_2_webForms.Dominio.Infra.RepositorioSingleton;

namespace Trabalho_2_webForms.Paginas.OrdemServicos
{
    public partial class Cadastro : PaginaBase, IPaginaCadastroBase
    {

        public OrdemServico EntidadeCadastro
        {
            get
            {
                return (Session["OrdemServico"] ?? (Session["OrdemServico"] == new OrdemServico())) as OrdemServico;
            }
            set
            {
                Session["OrdemServico"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TentarObterEntidadeIdUrl(OrdemServicoRepositorio, out var entidadeExistente);
                EntidadeCadastro = entidadeExistente;
                SetarDadosCadastro();
                CarregarItesnComponentes();
            }
        }

        private void CarregarItesnComponentes()
        {
            ddlCliente.CarregarItens(ClienteRepositorio.ListaTodos());

            ddlUsuario.CarregarItens(UsuarioRepositorio.ListaTodos());

            ddlServico.CarregarItens(ServicoRepositorio.ListaTodos());
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TratarCadastro(() =>
            {
                MontarDadosCadastro();
                if (!ValidarEntidaeCadastro(EntidadeCadastro)) return;

                OrdemServicoRepositorio.Salvar(EntidadeCadastro);
                AdicionarTextoSucesso("Salvo com Sucesso");
            });
        }

        public void LimparCampos()
        {

        }

        public void SetarDadosCadastro()
        {
            
        }

        public void MontarDadosCadastro()
        {
            
        }
    }
}