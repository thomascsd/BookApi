using AutoMapper;
using BookApi.Core.Dtos.Books;
using BookApi.DataAccess;

namespace BookApi.Service
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<AddBookDto, Book>();
        }
    }
}