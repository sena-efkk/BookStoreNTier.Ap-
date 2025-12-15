namespace BookStoreNTier.Service.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }
    }
}