using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Commands.Generation.AspNetCore;
using NSwag.Generation.AspNetCore;

namespace Helmer.PetStore.Nswag.ClientGenerator;

public class DocumentGenerator
{
    /// <summary>
    /// https://stackoverflow.com/questions/75753448/how-to-generate-the-openapi-json-with-nswag
    /// </summary>
    /// <param name="settings"></param>
    /// <returns></returns>
    public async Task<OpenApiDocument> GenerateAsync(AspNetCoreOpenApiDocumentGeneratorSettings settings)
    {
        var docGenerator = new AspNetCoreOpenApiDocumentGenerator(settings);
        // here we need the ApiExplorer whatever
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IApiDescriptionGroupCollectionProvider, FakeApiDescriptionGroupCollectionProvider>()
            .BuildServiceProvider();
        var document = await docGenerator.GenerateAsync(serviceProvider);
        return document;
    }
    
    /// <summary>
    /// With the command I need the Launcher.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<OpenApiDocument> GenerateByCommandAsync(AspNetCoreToOpenApiCommand command)
    {
        var document = (OpenApiDocument) await command.RunAsync(null, null);
        return document;
    }
    
    public async Task<OpenApiDocument> GenerateFromFileAsync(string basePath)
    {
        var nameSpace = "Helmer.Demo.PetStore.ClientGenerator";
        var swaggerPath = Path.Combine(basePath, nameSpace, "swagger.json");

        var document = await OpenApiDocument.FromFileAsync(swaggerPath);
        return document;
    }
}

public class FakeApiDescriptionGroupCollectionProvider : IApiDescriptionGroupCollectionProvider
{
    public ApiDescriptionGroupCollection ApiDescriptionGroups { get; }
}