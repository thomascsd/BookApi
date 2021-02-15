namespace BookApi.EF
{
    public class Book
    {
       
        public int BookID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int WriterID { get; set; }
    }
}