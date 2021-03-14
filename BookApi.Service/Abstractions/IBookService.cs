using BookApi.Core.Dtos.Books;
using System.Collections.Generic;

namespace BookApi.Service.Abstractions
{
    public interface IBookService
    {
        List<GetBooksDto> GetBooks();

        void AddBook(AddBookDto addBookDto);
    }
}