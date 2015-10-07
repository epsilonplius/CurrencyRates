using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CurrencyRates.Startup))]
namespace CurrencyRates
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
