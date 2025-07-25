namespace ProductDisplaySystem.Models
{
    public class ProductWithCategory
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty; // ✅ This is the fix
    }
}
