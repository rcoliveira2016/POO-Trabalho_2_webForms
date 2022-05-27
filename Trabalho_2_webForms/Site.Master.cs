using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabalho_2_webForms
{
    public partial class SiteMaster : MasterPage
    {
        private string _textoErro;
        public string textoErro
        {
            get
            {
                SetarTextoStatus();
                return _textoErro;
            }
        }

        private string _textoSucesso;
        public string textoSucesso
        {
            get
            {
                SetarTextoStatus();
                return _textoSucesso;
            }
        }

        public void SetarTextoStatus()
        {
            divAlertaSucesso.Visible = !string.IsNullOrEmpty(_textoSucesso);
            divAlertaDanger.Visible = !string.IsNullOrEmpty(_textoErro);
        }

        public void AdicionarTextoErro(string texto)
        {
            _textoErro = texto;
            SetarTextoStatus();
        }

        public void AdicionarTextoSucesso(string texto)
        {
            _textoSucesso = texto;
            SetarTextoStatus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetarTextoStatus();
        }
    }
}