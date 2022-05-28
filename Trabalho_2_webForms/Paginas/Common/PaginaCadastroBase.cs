using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho_2_webForms.Dominio.Data;
using Trabalho_2_webForms.Dominio.Entidades;

namespace Trabalho_2_webForms.Paginas.Common
{
    public abstract class PaginaCadastroBase<TEntidade>: PaginaBase, IPaginaCadastroBase where TEntidade : Entidade, new()
    {
        private RepositorioBase<TEntidade> _repositorio = new RepositorioBase<TEntidade>();

        public virtual RepositorioBase<TEntidade> Repositorio => _repositorio;
        public string name_key = typeof(TEntidade).FullName;
        public TEntidade EntidadeCadastro
        {
            get
            {
                return (Session[name_key] ?? (Session[name_key] == new TEntidade())) as TEntidade;
            }
            set
            {
                Session[name_key] = value;
            }
        }

        public virtual void LimparCampos()
        {
        }

        public abstract void MontarDadosCadastro();

        public abstract void SetarDadosCadastro();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TentarObterEntidadeIdUrl(Repositorio, out var entidadeExistente);
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

                Repositorio.Salvar(EntidadeCadastro);
                AdicionarTextoSucesso("Salvo com Sucesso");
            });
        }

    }

    internal interface IPaginaCadastroBase
    {
        void LimparCampos();
        void SetarDadosCadastro();
        void MontarDadosCadastro();
    }
}