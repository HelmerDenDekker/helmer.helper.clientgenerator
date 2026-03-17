using Helmer.Demo.PetStore.ClientGenerator;
using NSwag;
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


// TODO generate document, this feels way to complicated. So for now I am using NSwag.MSBuild to generate the swagger.json for me.
// var docGeneratorSettings = settingsProvider.Settings.DocumentGenerator.AspNetCoreToOpenApi;
// var docGenerator = new AspNetCoreOpenApiDocumentGenerator(docGeneratorSettings);
var clientSettings = settingsProvider.Settings.CodeGenerators.OpenApiToCSharpClientCommand;
var swaggerPath = Path.Combine(rootDirectory, srcDirectory, projectDirectoryName, clientSettings.Namespace, "swagger.json");

var document = await OpenApiDocument.FromFileAsync(swaggerPath);

// generate the client code

var generator = new CSharpClientGenerator(document, clientSettings.Settings);
var code = generator.GenerateFile();

var outputDirectory = Path.Combine(rootDirectory, srcDirectory, projectDirectoryName, clientSettings.Namespace);

if (!Directory.Exists(outputDirectory))
    throw new FileNotFoundException("Could not find the output directory.");

var allOneFile = Path.Combine(outputDirectory, $"{clientSettings.ClassName}.cs");

if (File.Exists(allOneFile))
    File.Delete(allOneFile);

using var streamWriter = File.AppendText(allOneFile);
streamWriter.Write(code);

