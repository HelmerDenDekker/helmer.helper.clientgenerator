using Helmer.Demo.PetStore.ClientGenerator;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.Generation.AspNetCore;

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
var docGeneratorSettings = settingsProvider.Settings.DocumentGenerator.AspNetCoreToOpenApi;
// Load the API assembly
var apiAssemblyPath = Path.Combine(rootDirectory, srcDirectory, "Helmer.Demo.PetStore.Api", "bin", "Debug", "net8.0", "Helmer.Demo.PetStore.Api.dll");

if (!File.Exists(apiAssemblyPath))
    throw new FileNotFoundException($"Could not find API assembly at {apiAssemblyPath}");

var apiAssembly = System.Reflection.Assembly.LoadFrom(apiAssemblyPath);

var docGenerator = new AspNetCoreOpenApiDocumentGenerator(docGeneratorSettings);
var document = await docGenerator.GenerateAsync(apiAssembly);
//await document.SaveAsync("openapi.json");

var clientSettings = settingsProvider.Settings.CodeGenerators.OpenApiToCSharpClientCommand;

// // this namespace
// var nameSpace = "Helmer.Demo.PetStore.ClientGenerator";
// var swaggerPath = Path.Combine(rootDirectory, srcDirectory, projectDirectoryName, nameSpace, "swagger.json");
//
// var document = await OpenApiDocument.FromFileAsync(swaggerPath);


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

