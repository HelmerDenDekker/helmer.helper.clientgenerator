using Helmer.Demo.PetStore.ClientGenerator;
using NSwag.CodeGeneration.CSharp;

// read the nswag.json file

var settingsProvider = new SettingsProvider();
await settingsProvider.InitializeAsync();

// I hate to do this...
const string srcDirectory = "src";
const string projectDirectoryName = "generateClientFromApiHelper";

var rootDirectory = Path.GetFullPath(".");

while (rootDirectory != null && !Directory.Exists(Path.Combine(rootDirectory, srcDirectory)))
    rootDirectory = Path.GetDirectoryName(rootDirectory);

if (rootDirectory == null)
    throw new FileNotFoundException("Could not find the root directory.");

try
{
    var clientSettings = settingsProvider.Settings.CodeGenerators.OpenApiToCSharpClientCommand;
    var outputDirectory = Path.Combine(rootDirectory, srcDirectory, projectDirectoryName, clientSettings.Namespace);

    if (!Directory.Exists(outputDirectory))
        throw new FileNotFoundException("Could not find the output directory.");

    var documentGenerator = new DocumentGenerator();
    //var docGeneratorSettings = settingsProvider.Settings.DocumentGenerator.AspNetCoreToOpenApi;
    //var document = await documentGenerator.GenerateByCommandAsync(docGeneratorSettings);


    var document =
        await documentGenerator.GenerateFromFileAsync(Path.Combine(rootDirectory, srcDirectory, projectDirectoryName));


    // generate the client code
    // TODO: There is something wrong in the nswag.json settings file.
    var setting = new CSharpClientGeneratorSettings
    {
        CSharpGeneratorSettings =
        {
            Namespace = clientSettings.Namespace
        },
        GenerateClientInterfaces = true
    };
    var generator = new CSharpClientGenerator(document, setting);
    var code = generator.GenerateFile();
    
    var allOneFile = Path.Combine(outputDirectory, $"{clientSettings.ClassName}.cs");

    if (File.Exists(allOneFile))
        File.Delete(allOneFile);

    using var streamWriter = File.AppendText(allOneFile);
    streamWriter.Write(code);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}