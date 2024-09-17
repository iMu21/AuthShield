namespace AuthShield.Application.Model
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int Category { get; set; }
    }
}
