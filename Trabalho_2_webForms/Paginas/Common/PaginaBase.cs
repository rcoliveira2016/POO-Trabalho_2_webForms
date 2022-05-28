using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabalho_2_webForms.Dominio.Data;
using Trabalho_2_webForms.Dominio.Entidades;

namespace Trabalho_2_webForms.Paginas.Common
{
    public abstract class PaginaBase : System.Web.UI.Page
    {
        public void AdicionarTextoErro(string texto) => (Master as SiteMaster).AdicionarTextoErro(texto);
        public void AdicionarTextoSucesso(string texto) => (Master as SiteMaster).AdicionarTextoSucesso(texto);

        protected void TratarErro(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }
        }

        protected void TratarCadastro(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exc)
            {
                (Master as SiteMaster).AdicionarTextoErro(exc.Message);
            }
        }
        protected virtual T ValorDefaultEntidade<T>() where T : Entidade, new()
        {
            return new T();
        }
        protected bool TentarObterEntidadeIdUrl<T>(RepositorioBase<T> repositorio, out T entidade) where T : Entidade, new()
        {
            if (!long.TryParse(Request.Params["Id"], out var id))
            {
                entidade = ValorDefaultEntidade<T>();
                return false;
            }

            entidade = repositorio.BuscarPorId(id);
            return true;
        }
        public bool ValidarEntidaeCadastro<T>(T entidade) where T : Entidade
        {
            if (!entidade.ValidarDados(out var msg))
            {
                AdicionarTextoErro($"{msg.Aggregate((a, b) => $"{a}, {b}")}");
                return false;
            }
            return true;
        }

        public void DesabilitarTodosCamposTela(params Control[] ignorar)
        {
            DesabilitarTodosCamposTela(Controls, ignorar);
        }

        public void DesabilitarTodosCamposTela(ControlCollection controls, IEnumerable<Control> ignorar = null)
        {
            foreach (Control item in controls)
            {
                if (ignorar?.Any(x => x.ID == item.ID)??false) continue;

                if(item is DropDownList)
                    (item as DropDownList).Enabled = false;

                if (item is TextBox)
                    (item as TextBox).Enabled = false;

                if (item is Button && (item as Button).CommandName == "Salvar")
                    (item as Button).Enabled = false;

                DesabilitarTodosCamposTela(item.Controls, ignorar);
            }
        }
    }    
}