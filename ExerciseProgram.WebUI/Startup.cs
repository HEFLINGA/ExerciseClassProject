using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExerciseProgram.WebUI.Startup))]
namespace ExerciseProgram.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
