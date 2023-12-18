using NSwag;
using NSwag.CodeGeneration.CSharp;

//ToDo: These values from appsettings

// The project where the client needs to be generated in
string integrationDirectory = "Helmer.Demo.PetStore.Integration";

// The folder where the client needs to be generated in
string clientDirectory = "PetStore";

// Class Name
string clientName = "PetStoreApiClient";

// Root documentation directory
string documentationDirectory = ".documentation";

string yamlRootDirectory = "petstore";

string openapiFileName = "openapi.yaml";


var rootDirectory = Path.GetFullPath(".");

while (!Directory.Exists(Path.Combine(rootDirectory, documentationDirectory)))
{
	rootDirectory = Path.GetDirectoryName(rootDirectory);
	if (rootDirectory == null)
	{
		throw new FileNotFoundException("Could not find the root directory.");
	}
}

string path = Path.Combine(rootDirectory, documentationDirectory, yamlRootDirectory, openapiFileName);

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


//ToDo see if you can split the generated files

var outputDirectory = Path.Combine(rootDirectory, "src", integrationDirectory, clientDirectory);
var allOneFile = Path.Combine(outputDirectory, $"{clientName}.cs");

if (File.Exists(allOneFile)) File.Delete(allOneFile);

using (StreamWriter streamwriter = File.AppendText(allOneFile))
{
	streamwriter.Write(code);
}
