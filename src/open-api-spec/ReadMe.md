# Generate a client from API
2026-03-20

There are several ways to generate from API.

https://github.com/aspnet/Announcements/issues/518

## SwashBuckle

Somehow I read somewhere that there were problems using SwashBuckle with newer versions of .NET.    
It is not mentioned on the Microsoft website, but still seems to be very much alive.  
Since I was using NSwag for the code generation, and Swashbuckle themselves have lots of documentation, I am not going to add it here.

## NSwag

I added an example of how to use NSwag. I chose the NSwag.ConsoleCore tool because it can also run in a pipeline.  
There are a trazillion ways to use NSwag however, so pick your poison.  

Catch: Many of the issues you will encounter will be caused by misconfigurations. There are so many configuration options, that it is easy to make a mistake.

## Microsoft OpenAPI.NET

Microsoft OpenAPI.NET is a library for working with OpenAPI specifications. It provides tools for parsing, validating, and generating OpenAPI documents. You can use it to create a client from an OpenAPI specification.
It is largely deprecated since dotnet 10. I did try it out, and it was sweet. However, I am NOT going this route if it will be deprecated soon.

## Kiota

Kiota is the new way to go.
I will go and try this sometime in the (near) future.

## OpenApi Generator

This is another package microsoft recommends.