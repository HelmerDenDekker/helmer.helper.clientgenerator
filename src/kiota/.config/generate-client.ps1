$baseNameSpace = "Helmer.PetStore.Kiota"
$apiProject = "$baseNameSpace.Api"

$clientProject = "$baseNameSpace.Client"
$version = Get-Date -Format "yyyy.M.d.HHmm"

Write-Host $clientProject

Set-Location ../../

Write-Host Restore solution
dotnet restore

Set-Location kiota

Write-Host Restore dotnet tools
dotnet tool restore

# Build API
Write-Host Build API and generate the openapi json
dotnet build $apiProject\$apiProject.csproj --no-restore

$openApiFilePath = "$PSScriptRoot\$apiProject.json"

if (-not( Test-Path $openApiFilePath)){
    throw "Failed to generate openapi json"
}

# Generate client files
Write-Host Generate client files
dotnet kiota generate -l CSharp -c Client -n $clientProject -d $openApiFilePath -o ./$clientProject/Generated

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
