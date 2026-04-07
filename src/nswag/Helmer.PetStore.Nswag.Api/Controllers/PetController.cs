using Asp.Versioning;
using Helmer.PetStore.Nswag.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helmer.PetStore.Nswag.Api.Controllers;

/// <summary>Everything about your Pets</summary>
[ApiController]
[Route("[controller]")]
[ApiVersion(1)]
[Produces("application/json")]
public class PetController : ControllerBase
{
    /// <summary>Update an existing pet.</summary>
    /// <remarks>Update an existing pet by Id.</remarks>
    [HttpPut]
    [ProducesResponseType(typeof(Pet), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult UpdatePet([FromBody] Pet pet)
    {
        // TODO: implement
        return Ok(pet);
    }

    /// <summary>Add a new pet to the store.</summary>
    /// <remarks>Add a new pet to the store.</remarks>
    [HttpPost]
    [ProducesResponseType(typeof(Pet), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult AddPet([FromBody] Pet pet)
    {
        // TODO: implement
        return Ok(pet);
    }

    /// <summary>Finds Pets by status.</summary>
    /// <remarks>Multiple status values can be provided with comma separated strings.</remarks>
    [HttpGet("findByStatus")]
    [ProducesResponseType(typeof(IEnumerable<Pet>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult FindPetsByStatus([FromQuery] string status = "available")
    {
        // TODO: implement
        return Ok(Array.Empty<Pet>());
    }

    /// <summary>Finds Pets by tags.</summary>
    /// <remarks>Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.</remarks>
    [HttpGet("findByTags")]
    [ProducesResponseType(typeof(IEnumerable<Pet>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult FindPetsByTags([FromQuery] List<string> tags)
    {
        // TODO: implement
        return Ok(Array.Empty<Pet>());
    }

    /// <summary>Find pet by ID.</summary>
    /// <remarks>Returns a single pet.</remarks>
    [HttpGet("{petId:long}")]
    [ProducesResponseType(typeof(Pet), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetPetById([FromRoute] long petId)
    {
        // TODO: implement
        return NotFound();
    }

    /// <summary>Updates a pet in the store with form data.</summary>
    /// <remarks>Updates a pet resource based on the form data.</remarks>
    [HttpPost("{petId:long}")]
    [ProducesResponseType(typeof(Pet), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdatePetWithForm([FromRoute] long petId, [FromQuery] string? name, [FromQuery] string? status)
    {
        // TODO: implement
        return Ok();
    }

    /// <summary>Deletes a pet.</summary>
    /// <remarks>Delete a pet.</remarks>
    [HttpDelete("{petId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeletePet([FromRoute] long petId, [FromHeader(Name = "api_key")] string? apiKey)
    {
        // TODO: implement
        return Ok();
    }

    /// <summary>Uploads an image.</summary>
    /// <remarks>Upload image of the pet.</remarks>
    [HttpPost("{petId:long}/uploadImage")]
    [Consumes("application/octet-stream")]
    [ProducesResponseType(typeof(Models.ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UploadFile([FromRoute] long petId, [FromQuery] string? additionalMetadata)
    {
        // TODO: implement
        return Ok(new Models.ApiResponse { Code = 200, Type = "unknown", Message = "File uploaded." });
    }
}

