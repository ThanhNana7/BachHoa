using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BachHoa.Startup))]
namespace BachHoa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
