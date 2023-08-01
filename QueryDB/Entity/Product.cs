namespace Packet.Shared;

public class Product
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public int Count { get; set; }
    public float Cost { get; set; }
    public Category? Category { get; set; }
    public int? CategoryId { get; set; }
}
