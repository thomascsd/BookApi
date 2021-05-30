using System;

namespace BookApi.DataAccess
{
    public class Book : BaseModel
    {
        public int BookID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int WriterID { get; set; }

        public DateTime CreateTime { get; set; }
    }
}