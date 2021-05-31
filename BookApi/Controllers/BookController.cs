using BookApi.Core.Dtos.Books;
using BookApi.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService m_BookService;

        public BookController(IBookService bookService)
        {
            this.m_BookService = bookService;
        }

        [HttpGet("Books")]
        public async Task<IEnumerable<GetBooksDto>> GetBooks()
        {
            return await this.m_BookService.GetBooks();
        }
    }
}