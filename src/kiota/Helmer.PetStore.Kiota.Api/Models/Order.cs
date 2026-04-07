namespace Helmer.PetStore.Kiota.Api.Models;

public class Order
{
    public long? Id { get; set; }
    public long? PetId { get; set; }
    public int? Quantity { get; set; }
    public DateTime? ShipDate { get; set; }

    /// <summary>Order Status</summary>
    public OrderStatus? Status { get; set; }

    public bool? Complete { get; set; }
}

public enum OrderStatus
{
    Placed,
    Approved,
    Delivered
}

