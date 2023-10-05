namespace SneakerSellingSystem.Data.Models
{
    public class Category
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public IEnumerable<Sneaker> Sneakers { get; init; } = new List<Sneaker>();
    }
}
