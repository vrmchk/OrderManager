using OrderMangerCore.DAL.Entities.Base;

namespace OrderMangerCore.DAL.Entities
{
    public class Shipper : BaseEntity<int>
    {
        // public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = null!;
    }
}
 