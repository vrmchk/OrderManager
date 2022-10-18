namespace OrderManagerCore.Common.Models;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
    public byte[]? Picture { get; set; }
}