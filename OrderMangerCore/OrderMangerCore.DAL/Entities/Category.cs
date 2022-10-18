using OrderMangerCore.DAL.Entities.Base;

namespace OrderMangerCore.DAL.Entities
{
    public class Category : BaseEntity<int>
    {
        // public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; } = null!;
    }
}
