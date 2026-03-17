using Newtonsoft.Json;
using NSwag.Generation.AspNetCore;

namespace Helmer.Demo.PetStore.ClientGenerator.Models;

internal sealed class DocumentGeneratorSection
{
    [JsonProperty("aspNetCoreToOpenApi")]
    public AspNetCoreOpenApiDocumentGeneratorSettings? AspNetCoreToOpenApi { get; set; }
}