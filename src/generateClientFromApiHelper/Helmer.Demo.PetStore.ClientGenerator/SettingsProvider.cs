using Helmer.Demo.PetStore.ClientGenerator.Models;
using Newtonsoft.Json;

namespace Helmer.Demo.PetStore.ClientGenerator;

internal class SettingsProvider
{
    internal NswagSettings Settings { get; private set; } = null!;
    
    internal async Task InitializeAsync()
    {
        var nswagPath = Path.Combine(AppContext.BaseDirectory, "nswag.json");
        if (!File.Exists(nswagPath))
        {
            throw new FileNotFoundException($"Could not find NSwag config file at '{nswagPath}'.");
        }

        var json = await File.ReadAllTextAsync(nswagPath);
 
        Settings = JsonConvert.DeserializeObject<NswagSettings>(json)
                   ?? throw new InvalidOperationException("Failed to deserialize NSwag settings from nswag.json.");
    }
}