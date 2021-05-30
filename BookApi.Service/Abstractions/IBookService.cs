using BookApi.Core.Dtos.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Service.Abstractions
{
    public interface IBookService
    {
        Task<List<GetBooksDto>> GetBooks();

        Task AddBook(AddBookDto addBookDto);
    }
}