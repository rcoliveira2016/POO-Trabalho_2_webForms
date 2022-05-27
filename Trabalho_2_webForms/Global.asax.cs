using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Trabalho_2_webForms.Dominio.Entidades;
using static Trabalho_2_webForms.Dominio.Infra.RepositorioSingleton;
namespace Trabalho_2_webForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que é executado na inicialização do aplicativo
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AdicionarDadosIniciais();
        }

        private void AdicionarDadosIniciais()
        {
            if (!ClienteRepositorio.PossuiRegistro())
            {
                ClienteRepositorio.Adiciona(new Cliente() { CPF = "0000000000", DataNascimento = DateTime.Now.AddYears(-30), Endereco = "ssssssss, 2222, 555", Nome="Ramon", Telefone="(54) 99999-9999" });
            }
        }
    }
}