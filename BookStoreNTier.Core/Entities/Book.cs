namespace BookStoreNTier.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }
    }
}
