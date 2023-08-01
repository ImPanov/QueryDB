namespace QueryDB.Models;

public class ProductAndCategory
{
    public required string ProductName { get; set; }
    public int Count { get; set; }
    public float Cost { get; set; }
    public required string CategoryName { get; set; }
}
