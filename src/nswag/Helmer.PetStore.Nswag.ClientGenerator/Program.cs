using System.CommandLine;
using System.Reflection;
using NSwag;
using NSwag.CodeGeneration.CSharp;

var rootCommand = new RootCommand();

var swaggerFileOption = new Option<FileInfo>("--swaggerFile")
{
    Description = "The path to the swagger JSON definition file"
};
rootCommand.Options.Add(swaggerFileOption);

var outputOption = new Option<FileInfo>("--output")
{
    Description = "The path to output the generated file to"
};
rootCommand.Options.Add(outputOption);

rootCommand.SetAction((parseResult, cancellationToken) =>
{
    var output = parseResult.GetValue(outputOption);
    var swaggerFile = parseResult.GetValue(swaggerFileOption);
    return DoRootCommand(output, swaggerFile, cancellationToken);
});

await rootCommand.Parse(args).InvokeAsync();

async Task<int> DoRootCommand(FileInfo? output, FileInfo? swaggerFile, CancellationToken cancellationToken)
{
    if (output == null || string.IsNullOrEmpty(output.DirectoryName))
    {
        Console.WriteLine("Output option is required.");
        return 1;
    }

    if (swaggerFile == null)
    {
        Console.WriteLine("Swagger file option is required.");
        return 1;
    }

    if (File.Exists(output.FullName))
        File.Delete(output.FullName);

    Console.WriteLine("Ensure output directory: " + output.DirectoryName);
    Directory.CreateDirectory(output.DirectoryName);

    var swaggerJson = File.ReadAllText(swaggerFile.FullName);
    var document = await OpenApiDocument.FromJsonAsync(swaggerJson);

    var clientProjectNamespace = Assembly.GetExecutingAssembly().FullName
        !.Split(',')[0]
        .Replace(".ClientGenerator", ".Client");

    var settings = new CSharpClientGeneratorSettings
    {
        CSharpGeneratorSettings =
        {
            Namespace = clientProjectNamespace
        },
        GenerateClientInterfaces = true
    };

    var generator = new CSharpClientGenerator(document, settings);
    var code = generator.GenerateFile();
    File.WriteAllText(output.FullName, code);
    return 0;
}