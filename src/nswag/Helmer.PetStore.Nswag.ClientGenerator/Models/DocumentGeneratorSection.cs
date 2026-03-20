using Newtonsoft.Json;
using NSwag.Commands.Generation.AspNetCore;
using NSwag.Generation.AspNetCore;

namespace Helmer.Demo.PetStore.ClientGenerator.Models;

internal sealed class DocumentGeneratorSection
{
    [JsonProperty("aspNetCoreToOpenApi")]
    public AspNetCoreToOpenApiCommand? AspNetCoreToOpenApi { get; set; }
}