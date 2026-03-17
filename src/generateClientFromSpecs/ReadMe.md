## Generate a client from OpenAPI specifications

This project provides a tool to generate a client library from OpenAPI specifications. The generated client can be used to interact with APIs defined by the OpenAPI specifications, making it easier for developers to integrate with those APIs.

I chose for a ClientGenerator console app instead of using NSwag.Build because I want to generate the client only when I want it to update, and not automatically on a build step.