namespace BookApi.Core.Dtos.Books
{
    public class AddBookDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int WriterID { get; set; }
    }
}