using Newtonsoft.Json;
using NSwag.CodeGeneration.CSharp;

namespace Helmer.Demo.PetStore.ClientGenerator.Models;

internal sealed class CodeGeneratorsSection
{
    [JsonProperty("openApiToCSharpClient")]
    public CSharpClientGeneratorSettings? OpenApiToCSharpClient { get; set; }
}