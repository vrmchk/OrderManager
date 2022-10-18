using System.ComponentModel.DataAnnotations;

namespace OrderManagerCore.Common.Models;

public class OrderDetailViewModel
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    [Range(0, int.MaxValue)]
    public decimal UnitPrice { get; set; }
    [Range(1, short.MaxValue)]
    public short Quantity { get; set; }
    [Range(0, 1)]
    public float Discount { get; set; }
}