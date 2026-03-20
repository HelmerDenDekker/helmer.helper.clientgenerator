## Generate a client from API

There are several ways to generate from API.

https://github.com/aspnet/Announcements/issues/518

### SwashBuckle

Somehow I read somewhere that there were problems using SwashBuckle with newer versions of .NET.  
However, the package still seems supported.

### NSwag

Microsoft recommends NSwag.

### Microsoft OpenAPI.NET

Microsoft OpenAPI.NET is a library for working with OpenAPI specifications. It provides tools for parsing, validating, and generating OpenAPI documents. You can use it to create a client from an OpenAPI specification.
It is largely deprecated since dotnet 10. So....

### Kiota

Kiota is the new way to go.

## OpenApi Generator

This is another package microsoft recommends.