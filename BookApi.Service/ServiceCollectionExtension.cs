using BookApi.Service.Abstractions;
using BookApi.Service.Impls;
using Microsoft.Extensions.DependencyInjection;

namespace BookApi.Service
{
    public static class ServiceCollectionExtension
    {
        public static ServiceCollection AddBookService(this ServiceCollection service)
        {
            service.AddTransient<IBookService, BookService>();

            return service;
        }
    }
}