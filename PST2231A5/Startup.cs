using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PST2231A5.Startup))]

namespace PST2231A5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
