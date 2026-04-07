$baseNameSpace = "Helmer.PetStore.Nswag"
$apiProject = "$baseNameSpace.Api"
$dotnetVersion = "net10.0"

$clientProject = "$baseNameSpace.Client"
$generatorProject = "$baseNameSpace.ClientGenerator"
$version = Get-Date -Format "yyyy.M.d.HHmm"

Write-Host $clientProject

Set-Location ../../

Write-Host dotnet restore solution
dotnet restore

Set-Location nswag

Write-Host dotnet restore tools
dotnet tools restore

# Build generator
Write-Host Build generator
dotnet build $generatorProject\$generatorProject.csproj --no-restore

# Build API
Write-Host Build API
dotnet build $apiProject\$apiProject.csproj --no-restore

# Generate swagger.json. Using nswag run with globally installed nswag because of bug: dotnet tool install -g NSwag.ConsoleCore --framework net8.0
Write-Host Generate swagger.json

dotnet nswag run .config/nswag.json

$swaggerFilePath = "$PSScriptRoot\swagger.json"

if (-not( Test-Path $swaggerFilePath)){
    throw "Failed to generate swagger.json"
}

# Generate client files
Write-Host Generate client files
dotnet $generatorProject\bin\Debug\$dotnetVersion\$generatorProject.dll --swaggerFile .config/swagger.json --output $clientProject\Generated\Client.cs

Remove-Item $swaggerFilePath

# Generate nuget package
Write-Host Generating nuget packages
$packPath = "$PSScriptRoot\pack"
if(Test-Path $packPath) {
    Write-Host Removing pack
    Remove-Item -Path $packPath -Recurse
}

dotnet pack -p:PackageVersion=$version $clientProject\$clientProject.csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg --configuration release --output $packPath

Set-Location $PSScriptRoot

#Copy nuget package to local folder
if(Test-Path Env:LocalNugetPath) {
    $localNugetPath = Get-Item Env:LocalNugetPath
    Move-Item -Path $packPath\* -Destination $localNugetPath.Value -Include *.nupkg, *.snupkg -Force
    Remove-Item -Path $packPath -Recurse
}


