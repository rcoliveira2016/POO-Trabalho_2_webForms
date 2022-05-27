using System;
using System.Web.UI.WebControls;
using Trabalho_2_webForms.Dominio.Infra.Extensoes;
using Trabalho_2_webForms.Paginas.Common;
using static Trabalho_2_webForms.Dominio.Infra.RepositorioSingleton;

namespace Trabalho_2_webForms.Paginas.Usuarios
{
    public partial class Listagem : PaginaBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            grdDados.CarregarDadosGrid(UsuarioRepositorio);
        }

        protected void grdDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TratarErro(() =>
            {
                var codigo = Convert.ToInt64(e.Values[0]);
                UsuarioRepositorio.Deletar(codigo);
                AdicionarTextoSucesso("usuário excluido com sucesso");
                CarregarListagem();
            });
        }

        protected void grdDados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TratarErro(() =>
            {
                grdDados.RedirecionarPaginaCadastro(e, Response, "Usuarios");
            });
        }
    }
}