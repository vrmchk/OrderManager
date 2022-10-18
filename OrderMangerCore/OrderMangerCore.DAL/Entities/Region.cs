using OrderMangerCore.DAL.Entities.Base;

namespace OrderMangerCore.DAL.Entities
{
    public class Region : BaseEntity<int>
    {
        // public int RegionId { get; set; }
        public string RegionDescription { get; set; } = null!;

        public virtual ICollection<Territory> Territories { get; set; } = null!;
    }
}
