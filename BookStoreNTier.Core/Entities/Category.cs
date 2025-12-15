namespace BookStoreNTier.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; } // Db'de Slug olacak, ayarı sonra yapacağız.

        public ICollection<Book> Books { get; set; }
    }
}