using System;
using Trabalho_2_webForms.Dominio.Data;
using Trabalho_2_webForms.Dominio.Entidades;
using Trabalho_2_webForms.Dominio.Infra;
using Trabalho_2_webForms.Dominio.Infra.Extensoes;
using Trabalho_2_webForms.Paginas.Common;

namespace Trabalho_2_webForms.Paginas.Servicos
{
    public partial class Cadastro : PaginaCadastroBase<Servico>
    {
        public override void SetarDadosCadastro()
        {
            txtNome.Text = EntidadeCadastro.Nome;
            txtDescricao.Text = EntidadeCadastro.Descricao;
            txtValorUnitario.Text = EntidadeCadastro.ValorUnitario.ToString();
            txtId.Text = EntidadeCadastro.Id.ToString();
        }

        public override void MontarDadosCadastro()
        {
            EntidadeCadastro.Nome = txtNome.Text;
            EntidadeCadastro.Descricao = txtDescricao.Text;
            if(txtValorUnitario.TentarObterDouble(out var valorUnitario))
                EntidadeCadastro.ValorUnitario = valorUnitario;
        }
    }
}