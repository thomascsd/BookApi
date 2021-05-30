namespace BookApi.DataAccess
{
    public class Writer : BaseModel
    {
        public int WriterID { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }
    }
}