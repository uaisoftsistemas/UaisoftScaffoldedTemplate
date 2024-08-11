using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.EntityFrameworkCore.Design;

namespace UaisoftScaffoldedTemplate
{
    public class ScaffoldRegistration : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddSingleton<ICodeGenerator, MyScaffold>();
        }
    }
}
