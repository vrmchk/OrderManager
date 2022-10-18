using OrderMangerCore.DAL.Entities.Base;

namespace OrderMangerCore.DAL.Entities
{
    public class Territory : BaseEntity<string>
    {
        // public string TerritoryId { get; set; } = null!;
        public string TerritoryDescription { get; set; } = null!;
        public int RegionId { get; set; }

        public virtual Region Region { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = null!;
    }
}
