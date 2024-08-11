using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.IO;
using System;

namespace UaisoftScaffoldedTemplate
{
    [Alias("customrazorcrud")]
    public class MyScaffold : ICodeGenerator
    {
        private readonly ICodeGeneratorActionsService _codeGeneratorActionsService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MyScaffold> _logger;

        public MyScaffold(
            ICodeGeneratorActionsService codeGeneratorActionsService,
            IServiceProvider serviceProvider,
            ILogger<MyScaffold> logger)
        {
            _codeGeneratorActionsService = codeGeneratorActionsService;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        // Método GenerateCode que a ferramenta está procurando
        public async Task GenerateCode(RazorComponentGeneratorModel model)
        {
            string[] templates = { "Create.razor.cshtml", "Edit.razor.cshtml", "Delete.razor.cshtml", "Details.razor.cshtml", "Index.razor.cshtml" };

            foreach (var template in templates)
            {
                string templatePath = Path.Combine("Templates", "RazorComponent", template);
                string outputPath = Path.Combine("Pages", model.EntityName, template.Replace(".cshtml", ".razor"));

                await _codeGeneratorActionsService.AddFileFromTemplateAsync(
                    outputPath,    // Caminho de saída do arquivo gerado
                    templatePath,  // Caminho do template
                    null,          // Parâmetro null para dados adicionais
                    model          // O modelo que será utilizado para substituir os placeholders no template
                );
            }
        }
    }

    public class RazorComponentGeneratorModel
    {
        public string EntityName { get; set; }
        public string Namespace { get; set; }
    }
}
