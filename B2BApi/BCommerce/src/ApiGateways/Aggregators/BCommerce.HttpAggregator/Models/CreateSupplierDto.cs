namespace BCommerce.HttpAggregator.Models
{
    public class CreateSupplierDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
