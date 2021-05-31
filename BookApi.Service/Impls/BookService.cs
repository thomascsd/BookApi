using AutoMapper;
using BookApi.Core.Dtos.Books;
using BookApi.DataAccess;
using BookApi.Service.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Service.Impls
{
    public class BookService : IBookService
    {
        private readonly IDataService m_DataService;
        private readonly IMapper m_Mapper;
        private const string BASE_ID= "app9WAzfdktS0w1Oz";

        public BookService(IDataService dataService, IMapper mapper)
        {
            this.m_DataService = dataService;
            this.m_Mapper = mapper;
        }

        public async Task<IEnumerable<GetBooksDto>> GetBooks()
        {
            var books = await this.m_DataService.GetDatas<Book>(BASE_ID, "Book");
            var writers = await this.m_DataService.GetDatas<Writer>(BASE_ID, "Writer");

            var booksDto = (from b in books
                            join w in writers
                            on b.WriterID equals w.WriterID
                            select new GetBooksDto
                            {
                                BookID = b.BookID,
                                Description = b.Description,
                                Title = b.Title,
                                WriterName = w.Name
                            }).ToList();

            return booksDto;
        }

        public async Task AddBook(AddBookDto addBookDto)
        {
            Book book = this.m_Mapper.Map<Book>(addBookDto);
            await this.m_DataService.SaveData(BASE_ID, "Book", book);
        }
    }
}