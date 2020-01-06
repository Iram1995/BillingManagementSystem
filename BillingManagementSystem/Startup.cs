using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BillingManagementSystem.Startup))]
namespace BillingManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
