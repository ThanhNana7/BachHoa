using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BachHoa1.Startup))]
namespace BachHoa1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
