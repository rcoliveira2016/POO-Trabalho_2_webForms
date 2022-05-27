using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        protected bool TentarObterEntidadeIdUrl<T>(RepositorioBase<T> repositorio, out T entidade) where T : Entidade, new()
        {
            if (!long.TryParse(Request.Params["Id"], out var id))
            {
                entidade = (new T());
                return false;
            }

            entidade = repositorio.Selecionar(id);
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
    }

    internal interface IPaginaCadastroBase
    {
        void LimparCampos();
        void SetarDadosCadastro();
        void MontarDadosCadastro();
    }
}