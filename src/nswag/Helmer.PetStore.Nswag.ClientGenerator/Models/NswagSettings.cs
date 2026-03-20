using Newtonsoft.Json;
using NSwag.Commands;
using NSwag.Commands.CodeGeneration;

namespace Helmer.Demo.PetStore.ClientGenerator.Models;

internal sealed class NswagSettings
{
    [JsonProperty("documentGenerator")]
    public DocumentGeneratorSection? DocumentGenerator { get; set; }

    [JsonProperty("codeGenerators")]
    public CodeGeneratorCollection CodeGenerators { get; } = new CodeGeneratorCollection();
}

internal class CodeGeneratorCollection
{
    [JsonProperty("OpenApiToTypeScriptClient", NullValueHandling = NullValueHandling.Ignore)]
    public OpenApiToTypeScriptClientCommand OpenApiToTypeScriptClientCommand { get; set; }

    /// <summary>Gets or sets the SwaggerToCSharpClientCommand.</summary>
    [JsonProperty("OpenApiToCSharpClient", NullValueHandling = NullValueHandling.Ignore)]
    public OpenApiToCSharpClientCommand OpenApiToCSharpClientCommand { get; set; }

    /// <summary>Gets or sets the SwaggerToCSharpControllerCommand.</summary>
    [JsonProperty("OpenApiToCSharpController", NullValueHandling = NullValueHandling.Ignore)]
    public OpenApiToCSharpControllerCommand OpenApiToCSharpControllerCommand { get; set; }

    /// <summary>Gets the items.</summary>
    [JsonIgnore]
    public IEnumerable<InputOutputCommandBase> Items => new InputOutputCommandBase[]
    {
        OpenApiToTypeScriptClientCommand,
        OpenApiToCSharpClientCommand,
        OpenApiToCSharpControllerCommand
    }.Where(cmd => cmd != null);
}
