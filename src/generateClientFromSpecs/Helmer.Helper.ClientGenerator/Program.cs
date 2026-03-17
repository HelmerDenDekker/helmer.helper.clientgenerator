using NSwag;
using NSwag.CodeGeneration.CSharp;

// The project where the client needs to be generated in
const string integrationDirectory = "Helmer.Demo.PetStore.Integration";

// The folder where the client needs to be generated in
const string clientDirectory = "PetStore";

// Class Name
const string clientName = "PetStoreApiClient";

// Root documentation directory
const string documentationDirectory = ".documentation";
const string yamlRootDirectory = "petstore";
const string openapiFileName = "openapi.yaml";

var rootDirectory = Path.GetFullPath(".");

while (rootDirectory != null && !Directory.Exists(Path.Combine(rootDirectory, documentationDirectory)))
    rootDirectory = Path.GetDirectoryName(rootDirectory);

if (rootDirectory == null)
    throw new FileNotFoundException("Could not find the root directory.");

var path = Path.Combine(rootDirectory, documentationDirectory, yamlRootDirectory, openapiFileName);

var document = await OpenApiYamlDocument.FromFileAsync(path);

var settings = new CSharpClientGeneratorSettings
{
    GenerateClientInterfaces = true,
    ClassName = clientName,
    InjectHttpClient = true,
    UseBaseUrl = false,
    CSharpGeneratorSettings =
    {
        Namespace = $"{integrationDirectory}.{clientDirectory}"
    }
};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();

var outputDirectory = Path.Combine(rootDirectory, "src", integrationDirectory, clientDirectory);

if (!Directory.Exists(outputDirectory))
    Directory.CreateDirectory(outputDirectory);

var allOneFile = Path.Combine(outputDirectory, $"{clientName}.cs");

if (File.Exists(allOneFile))
    File.Delete(allOneFile);

using var streamwriter = File.AppendText(allOneFile);
streamwriter.Write(code);