using System.Text.Json.Serialization;

namespace ProjektPP4.Models
{
    public class Category : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
