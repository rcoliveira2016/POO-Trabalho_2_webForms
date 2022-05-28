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
           
        }
    }
}