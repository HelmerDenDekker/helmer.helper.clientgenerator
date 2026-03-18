using Asp.Versioning;
using Helmer.Demo.PetStore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helmer.Demo.PetStore.Api.Controllers;

/// <summary>Operations about user</summary>
[ApiController]
[Route("[controller]")]
[ApiVersion(1)]
[Produces("application/json")]
public class UserController : ControllerBase
{
    /// <summary>Create user.</summary>
    /// <remarks>This can only be done by the logged in user.</remarks>
    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public IActionResult CreateUser([FromBody] User user)
    {
        // TODO: implement
        return Ok(user);
    }

    /// <summary>Creates list of users with given input array.</summary>
    [HttpPost("createWithList")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public IActionResult CreateUsersWithListInput([FromBody] List<User> users)
    {
        // TODO: implement
        return Ok(users.FirstOrDefault());
    }

    /// <summary>Logs user into the system.</summary>
    /// <remarks>Log into the system.</remarks>
    [HttpGet("login")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult LoginUser([FromQuery] string? username, [FromQuery] string? password)
    {
        // TODO: implement
        return Ok("token");
    }

    /// <summary>Logs out current logged in user session.</summary>
    /// <remarks>Log user out of the system.</remarks>
    [HttpGet("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult LogoutUser()
    {
        // TODO: implement
        return Ok();
    }

    /// <summary>Get user by user name.</summary>
    /// <remarks>Get user detail based on username.</remarks>
    [HttpGet("{username}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetUserByName([FromRoute] string username)
    {
        // TODO: implement
        return NotFound();
    }

    /// <summary>Update user resource.</summary>
    /// <remarks>This can only be done by the logged in user.</remarks>
    [HttpPut("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateUser([FromRoute] string username, [FromBody] User user)
    {
        // TODO: implement
        return Ok();
    }

    /// <summary>Delete user resource.</summary>
    /// <remarks>This can only be done by the logged in user.</remarks>
    [HttpDelete("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteUser([FromRoute] string username)
    {
        // TODO: implement
        return Ok();
    }
}

