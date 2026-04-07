using System.ComponentModel.DataAnnotations;

namespace Helmer.PetStore.Kiota.Api.Models;

public class Pet
{
    public long? Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public Category? Category { get; set; }

    [Required]
    public List<string> PhotoUrls { get; set; } = new();

    public List<Tag>? Tags { get; set; }

    /// <summary>pet status in the store</summary>
    public PetStatus? Status { get; set; }
}

public enum PetStatus
{
    Available,
    Pending,
    Sold
}

