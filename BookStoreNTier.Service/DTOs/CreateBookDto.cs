namespace BookStoreNTier.Service.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}