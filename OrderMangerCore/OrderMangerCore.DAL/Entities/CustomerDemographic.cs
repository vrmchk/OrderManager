using OrderMangerCore.DAL.Entities.Base;

namespace OrderMangerCore.DAL.Entities
{
    public class CustomerDemographic : BaseEntity<string>
    {
        // public string CustomerTypeId { get; set; } = null!;
        public string? CustomerDesc { get; set; }

        public virtual ICollection<Customer> Customers { get; set; } = null!;
    }
}
