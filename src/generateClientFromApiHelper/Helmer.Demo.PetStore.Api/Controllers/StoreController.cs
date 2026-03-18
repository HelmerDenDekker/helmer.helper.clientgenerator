using Asp.Versioning;
using Helmer.Demo.PetStore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helmer.Demo.PetStore.Api.Controllers;

/// <summary>Access to Petstore orders</summary>
[ApiController]
[Route("[controller]")]
[ApiVersion(1)]
[Produces("application/json")]
public class StoreController : ControllerBase
{
    /// <summary>Returns pet inventories by status.</summary>
    /// <remarks>Returns a map of status codes to quantities.</remarks>
    [HttpGet("inventory")]
    [ProducesResponseType(typeof(Dictionary<string, int>), StatusCodes.Status200OK)]
    public IActionResult GetInventory()
    {
        // TODO: implement
        return Ok(new Dictionary<string, int>());
    }

    /// <summary>Place an order for a pet.</summary>
    /// <remarks>Place a new order in the store.</remarks>
    [HttpPost("order")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public IActionResult PlaceOrder([FromBody] Order order)
    {
        // TODO: implement
        return Ok(order);
    }

    /// <summary>Find purchase order by ID.</summary>
    /// <remarks>For valid response try integer IDs with value &lt;= 5 or &gt; 10. Other values will generate exceptions.</remarks>
    [HttpGet("order/{orderId:long}")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetOrderById([FromRoute] long orderId)
    {
        // TODO: implement
        return NotFound();
    }

    /// <summary>Delete purchase order by identifier.</summary>
    /// <remarks>For valid response try integer IDs with value &lt; 1000. Anything above 1000 or non-integers will generate API errors.</remarks>
    [HttpDelete("order/{orderId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteOrder([FromRoute] long orderId)
    {
        // TODO: implement
        return Ok();
    }
}

