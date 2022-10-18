namespace OrderManagerCore.Common.Models;

public class OrderViewModel
{
    public int Id { get; set; }   
    public string? CustomerId { get; set; }
    public int? EmployeeId { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int? ShipperId { get; set; }
    public decimal? Freight { get; set; }
    public string? ShipName { get; set; }
    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipRegion { get; set; }
    public string? ShipPostalCode { get; set; }
    public string? ShipCountry { get; set; }
    
    public CustomerViewModel? Customer { get; set; }
    public EmployeeViewModel? Employee { get; set; }
    public ShipperViewModel? Shipper { get; set; }
    public List<OrderDetailViewModel> OrderDetails { get; set; } = new List<OrderDetailViewModel>();

}