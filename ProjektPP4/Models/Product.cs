namespace ProjektPP4.Models
{
    public class Product : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ean { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string Sku { get; set; } = string.Empty;
        public Category Category { get; set; } = default!;
        public string Material { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }

}
