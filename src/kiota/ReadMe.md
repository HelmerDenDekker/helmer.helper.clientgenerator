# Kiota

## Remarks

Creating the openApi document spec is a "thing".
It does not work from the command line, and this represents a problem.

I think this should be possible with the [Openapi.Server](https://www.nuget.org/packages/Microsoft.OpenApi/) package, but be careful about the support. I think they will stop supporting it.


## Steps: 

- Generate the openApi document spec from the API project, by pressing " Build" in VS or Rider (or other IDE?).
- Run the powerscript to generate and pack. 