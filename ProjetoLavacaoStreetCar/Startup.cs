using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoLavacaoStreetCar.Startup))]
namespace ProjetoLavacaoStreetCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
