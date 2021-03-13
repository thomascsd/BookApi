using BookApi.Core.Dtos.Books;
using BookApi.DataAccess;
using BookApi.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookApi.Service.Impls
{
    public class BookService : IBookService
    {
        private BookContext m_context;
        public BookService(BookContext context)
        {
            this.m_context = context;
        }

        public void AddBook()
        {
            throw new NotImplementedException();
        }

        public List<GetBooksDto> GetBooks()
        {
            var books = (from b in this.m_context.Books
                         join w in this.m_context.Writers
                         on b.WriterID equals w.WriterID
                         select new GetBooksDto
                         {
                             BookID = b.BookID,
                             Description = b.Description,
                             Title = b.Title,
                             WriterName = w.Name
                         }).ToList();

            return books;
        }
    }
}
