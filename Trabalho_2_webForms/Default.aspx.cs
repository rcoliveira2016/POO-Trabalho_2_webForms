using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabalho_2_webForms.Dominio.Data;

namespace Trabalho_2_webForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var rep = new ClienteRepositorio();
            rep.Adiciona(new Dominio.Entidades.Cliente()
            {
                CPF = "111111",
                DataNascimento = DateTime.Now,
                Endereco = "ssssss",
                Nome = "222222",
                Telefone = "sssss"
            });
        }
    }
}