namespace BookApi.Core.Dtos.Books
{
    public class GetBooksDto
    {
        public int BookID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string WriterName { get; set; }
    }
}