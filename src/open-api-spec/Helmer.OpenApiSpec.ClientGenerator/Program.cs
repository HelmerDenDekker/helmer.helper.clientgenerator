using NSwag;
using NSwag.CodeGeneration.CSharp;

// The project where the client needs to be generated in
const string projectDirectoryName = "open-api-spec";
const string integrationDirectoryName = "Helmer.OpenApiSpec.Client";

// The folder where the client needs to be generated in
const string clientDirectory = "Generated";

// Class Name
const string clientName = "Client";

// Root documentation directory
const string documentationDirectory = ".documentation";
const string yamlRootDirectory = "petstore";
const string openapiFileName = "openapi.yaml";

try
{
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
            Namespace = $"{integrationDirectoryName}.{clientDirectory}"
        }
    };

    var generator = new CSharpClientGenerator(document, settings);
    var code = generator.GenerateFile();

    var outputDirectory =
        Path.Combine(rootDirectory, "src", projectDirectoryName, integrationDirectoryName, clientDirectory);

    if (!Directory.Exists(outputDirectory))
        Directory.CreateDirectory(outputDirectory);

    var allOneFile = Path.Combine(outputDirectory, $"{clientName}.cs");

    if (File.Exists(allOneFile))
        File.Delete(allOneFile);

    await using var streamWriter = File.AppendText(allOneFile);
    await streamWriter.WriteAsync(code);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}