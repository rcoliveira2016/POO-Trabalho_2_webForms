using System;
using System.Linq;
using System.Web.UI.WebControls;
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
                return (Session["OrdemServico"] ?? (Session["OrdemServico"] == OrdemServico.Criar())) as OrdemServico;
            }
            set
            {
                Session["OrdemServico"] = value;
            }
        }

        public double ValorTotal => EntidadeCadastro.CalcularValorTotal();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TentarObterEntidadeIdUrl(OrdemServicoRepositorio, out var entidadeExistente);
                EntidadeCadastro = entidadeExistente.RegistroNovo ?
                    OrdemServico.Criar() : entidadeExistente;

                CarregarItesnComponentes();
                SetarDadosCadastro();
            }
        }

        private void CarregarItesnComponentes()
        {
            ddlCliente.CarregarItens(ClienteRepositorio.ListaTodos());

            ddlUsuario.CarregarItens(UsuarioRepositorio.ListaTodos());

            ddlServico.CarregarItens(ServicoRepositorio.ListaTodos());
            CarregaritemFrete();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TratarCadastro(() =>
            {
                MontarDadosCadastro();
                EntidadeCadastro.SetarValorParaSalvar();
                if (!ValidarEntidaeCadastro(EntidadeCadastro)) return;

                OrdemServicoRepositorio.Salvar(EntidadeCadastro);
                AdicionarTextoSucesso("Salvo com Sucesso");
            });
        }

        private void CarregaritemFrete()
        {
            var tiposFrete = Enum.GetValues(typeof(eTipoFormaPagamento))
                .Cast<eTipoFormaPagamento>()
                .ToList();

            ddlTipoFormaPagamento.Items.Add(new ListItem("", ""));
            foreach (var item in tiposFrete)
            {
                ddlTipoFormaPagamento.Items.Add(new ListItem(item.GetEnumDescription(), Convert.ToInt32(item).ToString()));
            }
            ddlTipoFormaPagamento.DataBind();
        }

        public void LimparCampos()
        {

        }

        public void SetarDadosCadastro()
        {
            divIdOrdemServico.Visible = !EntidadeCadastro.RegistroNovo;
            ddlCliente.SelectedValue = EntidadeCadastro.IdCliente.ToString();
            ddlServico.SelectedValue = EntidadeCadastro.IdServico.ToString();
            ddlUsuario.SelectedValue = EntidadeCadastro.IdUsuario.ToString();
            ddlTipoFormaPagamento.SelectedValue = ((int)EntidadeCadastro.Pagamento.FormaPagamento.Tipo).ToString();
            txtUnitario.Text = EntidadeCadastro.Unitario.ToString();
            SetarDivPagamento();
            
            if(!EntidadeCadastro.RegistroNovo)
                DesabilitarTodosCamposTela(txtUnitario, ddlCliente, ddlUsuario);
        }

        public void MontarDadosCadastro()
        {
            if (ddlCliente.TentarObterLong(out var idCliente))
                EntidadeCadastro.IdCliente = idCliente;

            if (ddlServico.TentarObterLong(out var idServico))
                EntidadeCadastro.IdServico = idServico;

            if (ddlUsuario.TentarObterLong(out var idusuario))
                EntidadeCadastro.IdUsuario = idusuario;

            if (ddlTipoFormaPagamento.TentarObterLong(out var tipoPagamento) && tipoPagamento != default(long))
                EntidadeCadastro.Pagamento.FormaPagamento.Tipo = (eTipoFormaPagamento)tipoPagamento;

            if (txtUnitario.TentarObterInt(out var unitario))
                EntidadeCadastro.Unitario = unitario;

            MontarDadosPagamento();
        }

        public void MontarDadosPagamento()
        {
            EntidadeCadastro.Pagamento.FormaPagamento.NumeroCartão = txtNumeroCartao.Text;
            EntidadeCadastro.Pagamento.FormaPagamento.CodigoSegurança = txtCodigoSeguranca.Text;
            EntidadeCadastro.Pagamento.FormaPagamento.CodigoPix = txtCopiaPix.Text;
            EntidadeCadastro.Pagamento.FormaPagamento.CodigoBarra = txtBoleto.Text;
        }

        protected void ddlTipoFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoFormaPagamento.TentarObterLong(out var tipoPagamento))
                EntidadeCadastro.Pagamento.FormaPagamento.Tipo = (eTipoFormaPagamento)tipoPagamento;
            SetarDivPagamento();
        }

        public void SetarDivPagamento()
        {
            divPagamentoPix.Visible = divPagamentoCartao.Visible = divPagamentoBoleto.Visible = false;

            switch (EntidadeCadastro.Pagamento.FormaPagamento.Tipo)
            {
                case eTipoFormaPagamento.Pix:
                    divPagamentoPix.Visible = true;
                    txtCopiaPix.Text = Guid.NewGuid().ToString();
                    break;
                case eTipoFormaPagamento.Boleto:
                    divPagamentoBoleto.Visible = true;
                    txtBoleto.Text = new Random().Next(1000, int.MaxValue).ToString().PadRight(10, '0').PadLeft(14, '0');
                    break;
                case eTipoFormaPagamento.Cartao:
                    divPagamentoCartao.Visible = true;
                    txtCodigoSeguranca.Text = EntidadeCadastro.Pagamento.FormaPagamento.CodigoSegurança;
                    txtNumeroCartao.Text = EntidadeCadastro.Pagamento.FormaPagamento.NumeroCartão;
                    break;
                default:
                    break;
            }
        }
    }
}